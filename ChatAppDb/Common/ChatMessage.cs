using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common
{
    public class ChatMessage
    {
        public const int BUFFER_LENGTH = 2048;

        public string Sender { get; private set; }
        public string Body { get; private set; }

        private ChatMessage()
        {
        }

        public ChatMessage(string sender, string messageBody)
        {
            Sender = sender;
            Body = messageBody;
        }

        public byte[] Encode()
        {
            return Encoding.UTF8.GetBytes(this.ToString());
        }


        public override string ToString()
        {
            return $"{Sender}: {Body}";
        }

        public static ChatMessage FromBytes(byte[] source, int lenght)
        {
            return ChatMessage.FromString(Encoding.UTF8.GetString(source).Substring(0, lenght));
        }

        public static ChatMessage FromString(string source)
        {
            ChatMessage obj = new ChatMessage();

            string[] message_tokens = source.Split(":", 2);
            if(message_tokens.Length == 2)
            {
                obj.Sender = message_tokens[0];
                obj.Body = message_tokens[1].TrimStart();
            }
            else
            {
                throw new IOException("Malformed message received.");
            }

            return obj;
        }
    }
}
