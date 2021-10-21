using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Common;

namespace Server
{
    class Server
    {
        private IPEndPoint endpoint;
        private Socket socket;
        private IDatabaseHelper dbHelper;

        private Dictionary<int, (Socket, NetworkStream)> clientList;
        private readonly object _clientListLock = new object();
        private int nMaxClient = 10;
        private int _lastClientId = 0;

        private bool serverOn = false;
        public bool IsServerOn { get { return serverOn; } }
        public int NumberOfActiveClients { get { return clientList.Count; } }



        public Server(IPAddress ipAddress, int port)
        {
            this.endpoint = new IPEndPoint(ipAddress, port);

            clientList = new Dictionary<int, (Socket, NetworkStream)>();
        }

        public void Start(IDatabaseHelper dbHelper=null)
        {
            if(dbHelper != null)
            {
                this.dbHelper = dbHelper;
            }
            if(!serverOn)
            {
                socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(endpoint);
                socket.Listen(128);

                serverOn = true;
                Console.WriteLine("SERVER ONLINE");

                Task.Run(() => ListenLoop());
            }
        }

        private async void ListenLoop()
        {
            do
            {
                if(clientList.Count < nMaxClient)
                {
                    int clientId = -1;
                    try
                    {
                        Socket clientSocket = await Task.Factory.FromAsync(
                            new Func<AsyncCallback, object, IAsyncResult>(socket.BeginAccept),
                            new Func<IAsyncResult, Socket>(socket.EndAccept),
                            null).ConfigureAwait(false);

                        Console.WriteLine("[Server#ListenLoop] New connection");

                        NetworkStream stream = new NetworkStream(clientSocket, true);
                        // NOTE(bora): As listen loop is async, two instances may be appending
                        // to the list at the same time. Use a lock here to make sure there is
                        // no collision.
                        lock(_clientListLock)
                        {
                            clientId = GenerateNextClientId();
                            clientList.Add(clientId, (clientSocket, stream));
                        }

                        Task.Run(() => ListenOneClient(clientId));
                    }
                    catch(ObjectDisposedException)
                    {
                        // NOTE(bora): This loop may run a few times after the server is closed.
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine($"[Server#ListenLoop] ERROR({e.GetType()}) :: {e.Message}");
                        if(clientId != -1)
                        {
                            Console.WriteLine($"[Server#ListenLoop] Connection lost on Client #{clientId}");
                            DestroyClientConnection(clientId);
                        }
                    }

                }
                else
                {
                    // NOTE(bora): Prevent CPU burning
                    Thread.Sleep(500);
                }
            } while(serverOn);
        }

        private async void ListenOneClient(int clientId)
        {
            (_, NetworkStream stream) = clientList[clientId];

            while(serverOn)
            {
                try
                {
                    byte[] buffer = new byte[ChatMessage.BUFFER_LENGTH];
                    int nBytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)
                    .ConfigureAwait(false);
                    if(nBytesRead == 0)
                    {
                        // NOTE(bora): Potentially lost connection.
                        Console.WriteLine($"[Server#ListenOneClient] Client data is empty. ID: {clientId}");
                        break;
                    }

                    ChatMessage message = ChatMessage.FromBytes(buffer, nBytesRead);
                    Console.WriteLine($"MESSAGE({nBytesRead}) ::\n{message}\n");

                    if(dbHelper != null)
                    {
                        bool savedSuccessfully = dbHelper.SaveMessage(message);
                        if(!savedSuccessfully)
                        { 
                            Console.WriteLine($"[Server#ListenOneClient] Error on saving message :: {message}");
                        }
                    }

                    // NOTE(bora): Broadcast everyone (echo back to this client as well)
                    Broadcast(message, -1);
                }
                catch(IOException)
                {
                    Console.WriteLine($"[Server#ListenOneClient] Client #{clientId} hanged up");
                    break;
                }
            }

            DestroyClientConnection(clientId);
        }

        private async void Broadcast(ChatMessage message, int ignoredClietId)
        {
            foreach((int clientId, (_, NetworkStream stream)) in clientList)
            {
                if(clientId != ignoredClietId)
                {
                    try
                    {
                        byte[] buffer = message.Encode();
                        await stream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                    }
                    catch(IOException)
                    {
                        // NOTE(bora): Probably client disconnected but is not removed from the list yet.
                    }
                }
            }
        }

        private void DestroyClientConnection(int clientId)
        {
            try
            {
                (_, NetworkStream networkStream) = clientList[clientId];

                //Broadcast(new ChatMessage("HOST", "CLIENT DISCONNECTED"), -1);

                // NOTE(bora): Network stream owns the socket so it will handle
                // closing the socket.
                networkStream.Close();
                lock(_clientListLock)
                {
                    clientList.Remove(clientId);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"[Server#KeyNotFoundException] ERROR({e.GetType()}) ::\n{e.Message}\n");
            }
        }

        private void DestroyAllClientConnections()
        {
            lock(_clientListLock)
            {
                foreach((int clientId, _) in clientList)
                {
                    DestroyClientConnection(clientId);
                }
            }
        }

        public void Stop()
        {
            if(serverOn)
            {
                DestroyAllClientConnections();
                socket.Close();

                socket = null;
                serverOn = false;
                Console.WriteLine("Server Closed.\n");
            }
        }

        private int GenerateNextClientId()
        {
            return ++_lastClientId;
        }
    }
}
