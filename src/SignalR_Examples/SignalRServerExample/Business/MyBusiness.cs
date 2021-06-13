using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRServerExample.Hubs;

namespace SignalRServerExample.Business
{
    public class MyBusiness
    {
        /// <summary>
        /// IHubContext vasitesile biznes ve controller hissesinde webSocket ile isleye bilerik.
        /// interface vasitesile hub icerisinde gorulen isleri diger bir biznes hissesinde de yaza bilerik.
        ///
        /// Go to startUp.cs add service 'services.AddTransient<MyBusiness>();'
        /// </summary>
        private readonly IHubContext<MyHub> _hubContext;

        #region ctor

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        #endregion

        #region methods

        public async Task SendMessageAsync(string message)
        {
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }

        #endregion
    }
}
