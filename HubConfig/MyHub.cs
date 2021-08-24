using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRServer.HubConfig
{
    public class MyHub: Hub
    {
        public async Task askServer(string someTextFromClient)
        {
            
            string tempString = "start";
            int msgcnt=0;
            do {

                //if (someTextFromClient == "hey")
                //{
                //    tempString = "message was hey";
                //}
                //else
                //{
                //    tempString = "message was something else";
                //}
                Thread.Sleep(2000);
                msgcnt = msgcnt + 1;
                tempString = "Message count: " + msgcnt;
                await Clients.Client(this.Context.ConnectionId).SendAsync("askServerResponse", tempString);

                if (msgcnt==10)
                {
                    tempString = "Finished";
                }

                
            } while(msgcnt!=10);
            await Clients.Client(this.Context.ConnectionId).SendAsync("askServerResponse", tempString);
        }
    }
}
