using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

namespace SignalRServerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// biznes kodlari ile birlikde istifade ucun injection
        /// </summary>
        private readonly MyBusiness _myBusiness;
        /// <summary>
        /// bir basa istifade ucun injection
        /// </summary>
        private readonly IHubContext<MyHub> _hubContext;

        public HomeController(MyBusiness myBusiness, IHubContext<MyHub> hubContext)
        {
            _myBusiness = myBusiness;
            _hubContext = hubContext;
        }

        [HttpGet("{message}")]
        public async Task<IActionResult> Index(string message)
        {
            await _myBusiness.SendMessageAsync(message);
            return Ok();
        }
    }
}
