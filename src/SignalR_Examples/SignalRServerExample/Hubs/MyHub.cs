using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    /*
     * 1.appde oncelikle sonunda HUB deye adlandirilan class
     * yaradilir ve HUB classindan inheritance alir bununla
     * TCP protokolundan istifade edeceyik.
     *
     *
     *
     *
     *
     *
     *
     */
    public class MyHub:Hub
    {
        /// <summary>
        /// 2.message parametri qebul eden bu method icerisinde Hub-dan gelen
        /// Clients prop vasitesile .All butun istifadecilerde "receiveMessage"
        /// methodunu ise salib qebul olunan message param-i olara gonderirik
        ///
        /// 3. Goto StartUp class
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageAsync(string message)
        {
           await  Clients.All.SendAsync("receiveMessage",message);
        }
    }
}
