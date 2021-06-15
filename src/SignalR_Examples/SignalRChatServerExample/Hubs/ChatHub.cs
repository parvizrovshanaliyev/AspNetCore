using Microsoft.AspNetCore.SignalR;
using SignalRChatServerExample.Interfaces;

namespace SignalRChatServerExample.Hubs
{
    public class ChatHub : Hub<IChatStronglyTypedHub>
    {

    }
}
