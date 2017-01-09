using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Identity_Sample.Helpers;
using Microsoft.AspNet.SignalR.Hubs;

namespace Identity_Sample.Hubs
{
    [HubName("chathub")]
    public class ChatHub : Hub
    {
        public void Send(string name, string message, string token, string CurrentTime)
        {
            // Check for white space
            if (message.Length == 0 || String.IsNullOrWhiteSpace(message))
            {
                // Do nothing
            }
            else
            {
                // Verify if token is valid
                if (!TokenHelper.VerifyToken(name, token))
                {
                    Clients.Caller.addNewMessageToPage("Error", "Token is not valid !");
                    return;
                }

                CurrentTime = DateTime.Now.ToLongTimeString();

                // Call the addNewMessageToPage method to update clients.
                Clients.All.addNewMessageToPage(name, message, CurrentTime);
            }

        }

    }
}