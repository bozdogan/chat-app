using System;
using System.Collections.Generic;
using System.Text;

using Common;

namespace Server
{
    interface IDatabaseHelper
    {
        bool CheckConnection();
        bool SaveMessage(ChatMessage message);
        List<ChatMessage> GetMessages(string searchText=null, bool searchInMessages=false);
    }
}
