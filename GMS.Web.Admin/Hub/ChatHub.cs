using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace GMS.Web.Admin.Hub
{
    [HubName("chatHub")]

    public class ChatHub : Microsoft.AspNet.SignalR.Hub
    {
        public static readonly ChatHub Instance = new ChatHub();

        public void Send(string name, string message)
        {
            // 关键代码
            GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients.All.addNewMessageToPage(name, message);
        }
    }
}