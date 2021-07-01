using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAuth.Interfaces
{
    public interface IMessageHub
    {
        Task ReceiveMessage(string message);
    }
}
