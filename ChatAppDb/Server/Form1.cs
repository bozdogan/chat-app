using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common;

namespace Server
{
    public partial class Form1 : Form
    {
        private Server server;
        private DatabaseHelper dbHelper;

        public Form1()
        {
            Console.WriteLine("Server");
            InitializeComponent();
            dbHelper = new DatabaseHelper(Properties.Settings.Default.connectionString);
            server = new Server(IPAddress.Parse("0.0.0.0"), 5001);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            databaseStatusLb.Text = "";
            serverStatusLb.Text = "---";
            nClientActiveLb.Text = "0";
            DeactivateSearchPanel();


            Console.WriteLine($"[DEBUG] ::\n\n{ new DateTime(2021,10,18,19,0,0) - new DateTime(2021, 07, 27, 13, 0, 0) }\n");
        }

        private void startServerBt_Click(object sender, EventArgs e)
        {
            server.Start(dbHelper);
            serverStatusLb.ForeColor = Color.DarkGreen;
            serverStatusLb.Text = "ONLINE";
        }

        private void stopServerBt_Click(object sender, EventArgs e)
        {
            server.Stop();
            serverStatusLb.ForeColor = Color.DarkRed;
            serverStatusLb.Text = "OFFLINE";
        }

        private void ActivateSearchPanel()
        {
            searchPanel.Enabled = true;
            databaseStatusLb.Text = "(Database is available.)";
        }

        private void DeactivateSearchPanel()
        {
            searchPanel.Enabled = false;
            databaseStatusLb.Text = "DATABASE NOT CONNECTED";
        }

        private void messageSearchFindBt_Click(object sender, EventArgs e)
        {
            string searchText = searchQueryTx.Text;
            bool searchInMessages = byMessageRadio.Checked;
            messagePreviewTx.Text = JoinLines(dbHelper.GetMessages(searchText, searchInMessages));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nClientActiveLb.Text = server.NumberOfActiveClients.ToString();
            if(dbHelper.CheckConnection())
            {
                ActivateSearchPanel();
            }
            else
            {
                DeactivateSearchPanel();
            }
        }

        string JoinLines(List<ChatMessage> list)
        {
            if(list != null)
            {
                StringBuilder result = new StringBuilder();
                foreach(ChatMessage it in list)
                {
                    if(it.GetType() == typeof(GetMessagesResult))
                    {
                        result.Append(((GetMessagesResult) it).ToString());
                    }
                    else
                    {
                        result.Append(it.ToString());
                    }
                    result.Append("\r\n");
                }
                result.Append("\r\n");

                return result.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
