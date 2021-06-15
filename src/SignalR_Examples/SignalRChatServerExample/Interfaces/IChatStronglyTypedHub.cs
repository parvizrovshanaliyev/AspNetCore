using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRChatServerExample.Models;

namespace SignalRChatServerExample.Interfaces
{
    public interface IChatStronglyTypedHub
    {
        Task ClientJoinedAsync(string nickName);
        Task ClientsDataAsync(List<Client> clients);
        Task ReceiveMessageAsync(string clientNickName, string message);
        Task GroupsAsync(List<Group> groups);
    }
}
