using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using Common;

namespace Server
{
    public class DatabaseHelper : IDatabaseHelper
    {
        private string connectionString;
        public DatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool CheckConnection()
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch(Exception e)
            {
                Console.WriteLine($"[DatabaseHelper#CheckConnection] ERROR ::\n{e.ToString()}\n");
                return false;
            }

            return true;
        }

        public bool SaveMessage(ChatMessage message)
        {
            string query = "INSERT INTO Messages (Sender, Text, DateReceived)"
                           + "VALUES (@Sender, @Text, @DateReceived)";

            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@Sender", message.Sender);
            command.Parameters.AddWithValue("@Text", message.Body);
            command.Parameters.AddWithValue("@DateReceived", DateTime.Now);

            int rowsAffected = 0;

            try
            {
                conn.Open();
                rowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine($"[DatabaseHelper#SaveMessage] ERROR ::\n{e.ToString()}\n");
            }

            return rowsAffected > 0;
        }

        public List<ChatMessage> GetMessages(string searchText=null, bool searchInMessages = false)
        {
            string query = "SELECT * FROM Messages ";
            if(searchInMessages)
            {
                query += " WHERE Text LIKE '%' + @SearchText + '%';";
            }
            else
            {
                query += " WHERE Sender = @SearchText;";
            }

            List<ChatMessage> result = null;

            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@SearchText", searchText);

            try
            {
                conn.Open();
                using SqlDataReader dr = command.ExecuteReader();

                result = new List<ChatMessage>();
                while(dr.Read())
                {
                    result.Add(new GetMessagesResult(
                        dr.GetString(1),
                        dr.GetString(2),
                        dr.GetDateTime(3)));
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"[DatabaseHelper#GetMessages] ERROR ::\n{e.ToString()}\n");
            }

            return result;
        }
    }

    public class GetMessagesResult : ChatMessage
    {
        public DateTime Date { get; }
        public GetMessagesResult(string sender, string messageBody, DateTime date)
            : base(sender, messageBody)
        {
            Date = date;
        }

        public override string ToString()
        {
            return $"[{Date}] {Sender}: {Body}";
        }
    }
}
