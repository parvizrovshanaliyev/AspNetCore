using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRAuth.Interfaces;

namespace SignalRAuth.Hubs
{
    [Authorize(Roles = "Admin")]
    public class MessageHub : Hub<IMessageHub>
    {
        public async Task SendMessage(string message)
        {
            await Clients.Others.ReceiveMessage(message);
        }
    }
}