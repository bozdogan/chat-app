using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common;

namespace ChatAppClient
{
    public partial class StartWindow : Form
    {
        private Socket socket;
        private NetworkStream networkStream;

        private IPEndPoint endPoint;

        public StartWindow()
        {
            InitializeComponent();
        }

        private void connectBt_Click(object sender, EventArgs e)
        {
            try
            {
                string hostAddress = serverAddressTx.Text.Trim();
                endPoint = new IPEndPoint(IPAddress.Parse(hostAddress), 5001);
            }
            catch(FormatException)
            {
                endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5001);
            }

            try
            {
                StartConnection();
                if(networkStream != null)
                {
                    SwitchToChatWindow();
                }
                else
                {
                    throw new Exception("Could not connect");
                }
            }
            catch(SocketException err)
            {
                System.Diagnostics.Debug.WriteLine(err);
                DestroyConnection();
            }
        }

        private void SwitchToChatWindow()
        {
            this.Hide();
            ChatWindow chatWindow = new ChatWindow(nameTx.Text.Trim(), networkStream);
            chatWindow.Closed += (sender, args) => this.Close();
            chatWindow.Show();
        }

        private void StartWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DestroyConnection();
        }

        private void StartConnection()
        {
            socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endPoint);

            networkStream = new NetworkStream(socket, true);
        }

        private void DestroyConnection()
        {
            if(networkStream != null)
            {
                networkStream.Close();
                networkStream = null;
            }
        }

        private void changeServerLb_Click(object sender, EventArgs e)
        {
            if(!serverAddressTx.Visible)
            {
                serverAddressTx.Visible = true;
            }
        }
    }
}
