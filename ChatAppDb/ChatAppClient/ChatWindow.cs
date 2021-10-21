using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common;

namespace ChatAppClient
{
    public partial class ChatWindow : Form
    {
        // NOTE(bora): This is used for invoke pattern to make "cross-thread operation"
        private delegate void SafeCallDelegateMessage(string senderName, string messageText);
        private delegate void SafeCallDelegateStatus(string statusMessage);
        private string nickname;
        private NetworkStream networkStream;
        private bool disconnected;


        public ChatWindow(string nickname, NetworkStream networkStream)
        {
            InitializeComponent();
            this.nickname = nickname;
            this.networkStream = networkStream;
        }

        private void ChatWindow_Load(object sender, EventArgs e)
        {
            this.Text = $"ChatApp (nickname: {nickname})";
            Task.Run(() => ListenLoop());
        }

        private void sendBt_Click(object sender, EventArgs e)
        {
            string messageText = messageTx.Text;
            Task.Run(() => SendMessage(new ChatMessage(nickname, messageText)));
            if(!disconnected)
            {
                messageTx.Clear();
            }
        }

        void AppendToChatBoxSafe(ChatMessage message)
        {
            AppendToChatBoxSafe(message.Sender, message.Body);
        }

        void AppendToChatBoxSafe(string senderName, string messageText)
        {
            if(chatTx.InvokeRequired)
            {
                SafeCallDelegateMessage d = new SafeCallDelegateMessage(AppendToChatBox);
                chatTx.Invoke(d, new object[] { senderName, messageText });
            }
            else
            {
                AppendToChatBox(senderName, messageText);
            }
        }

        void AppendToChatBox(string senderName, string messageText)
        {
            string nameTag = $"\n{senderName}: ";

            chatTx.SelectionFont = new Font(chatTx.SelectionFont, FontStyle.Bold);
            chatTx.AppendText(nameTag);

            chatTx.SelectionFont = new Font(chatTx.SelectionFont, FontStyle.Regular);
            chatTx.AppendText(messageText);
        }

        void AppendToChatBoxSafe(string statusMessage)
        {
            if(chatTx.InvokeRequired)
            {
                SafeCallDelegateStatus d = new SafeCallDelegateStatus(AppendToChatBox);
                chatTx.Invoke(d, new object[] { statusMessage });
            }
            else
            {
                AppendToChatBox(statusMessage);
            }
        }

        void AppendToChatBox(string statusMessage)
        {
            chatTx.SelectionFont = new Font(chatTx.SelectionFont, FontStyle.Italic);
            chatTx.AppendText("\n" + statusMessage);
        }

        private async void SendMessage(ChatMessage message)
        {
            if(!disconnected)
            {
                byte[] message_bytes = message.Encode();
                await networkStream.WriteAsync(message_bytes, 0, message_bytes.Length).ConfigureAwait(false);
                System.Diagnostics.Debug.WriteLine($"[SendMessage]: {message_bytes.Length} bytes sent to the server.");
                System.Diagnostics.Debug.WriteLine(Encoding.UTF8.GetString(message_bytes));
            }
        }

        private async void ListenLoop()
        {
            while(true)
            {
                try
                {
                    byte[] buffer = new byte[ChatMessage.BUFFER_LENGTH];
                    int messageLen = await networkStream.ReadAsync(buffer, 0, buffer.Length)
                        .ConfigureAwait(false);

                    string message_str = Encoding.UTF8.GetString(buffer).Substring(0, messageLen);
                    ChatMessage message = ChatMessage.FromString(message_str);
                    
                    System.Diagnostics.Debug.WriteLine($"[MESSAGE] :: {message}");

                    AppendToChatBoxSafe(message);
                }
                catch(IOException)
                {
                    // NOTE(bora): Server disconnected. Maybe try to reconnect?
                    disconnected = true;
                    AppendToChatBoxSafe("Disconnected.");
                    break;
                }
            }
        }
    }
}
