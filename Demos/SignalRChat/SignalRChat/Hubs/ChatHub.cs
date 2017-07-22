using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.Caller.addNewMessageToPage("Chief", "delivering message");
            Clients.All.addNewMessageToPage(name, message);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            var user = Context.Request.User;
            return base.OnConnected();
        }
    }
}