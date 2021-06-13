using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs
{
    /*
     * 1.appde oncelikle sonunda HUB deye adlandirilan class
     * yaradilir ve HUB classindan inheritance alir bununla
     * TCP protokolundan istifade edeceyik.
     */
    public class MyHub:Hub
    {

        #region fields

        private static readonly List<string> Clients = new List<string>();

        #endregion
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
           await  base.Clients.All.SendAsync("receiveMessage",message);
        }


        /*
         * Context.ConnectinId Hub -a qosulan clientlari bir birinden ayirmaq ucun istifade
         * edilen sistem terefinden verilmis unique id-dir.
         */
        #region Overrides of Hub

        /// <summary>
        /// Baglanti zamani ise dusecek
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            //What are Connection Events? How to List All Clients?
            Clients.Add(Context.ConnectionId);
            await base.Clients.All.SendAsync("clients", Clients);
            await base.Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        /// <summary>
        /// Baglanti qopan zaman ise dusecek
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            //What are Connection Events? How to List All Clients?
            Clients.Remove(Context.ConnectionId);
            await base.Clients.All.SendAsync("clients", Clients);
            await base.Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }


        #endregion
    }
}
