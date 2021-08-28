using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRServer.HubConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRServer
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusCheckController : ControllerBase
    {
        private readonly IHubContext<MyHub> _hub;
        public StatusCheckController(IHubContext<MyHub> hub)
        {
            _hub = hub;
        }
        [HttpGet]
        public IActionResult GetStatus(string id)
        {
            var message = id + " - Message from SignalR";
            //var result = new TimeManager(() => _hub.Clients.All.SendAsync("transferData", message));//send message to all clinet
            var result = new TimeManager(() => _hub.Clients.Client(id).SendAsync("transferData", message)); //send only to the connectionID
            return Ok(new { message="Request Completed"});
        }
    }
}
