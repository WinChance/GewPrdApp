using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace GMS.Web.Admin.Service.SignalR
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        public static readonly ChatHub Instance=new ChatHub();

        public void Send(string name, string message)
        {
            try
            {
                // Call the broadcastMessage method to update clients.
                //Clients.All.broadcastMessage(name, message);
                Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients.All.broadcastMessage(name, message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

    }
}