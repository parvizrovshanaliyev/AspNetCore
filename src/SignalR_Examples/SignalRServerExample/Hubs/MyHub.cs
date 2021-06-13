using System;
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
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        /// <summary>
        /// Baglanti qopan zaman ise dusecek
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }


        #endregion
    }
}
