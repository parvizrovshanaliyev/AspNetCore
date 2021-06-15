using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatServerExample.Interfaces
{
    public interface IChatStronglyTypedHub
    {
        Task ClientJoined(string nickName);
    }
}
