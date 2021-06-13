using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Interfaces
{
    /// <summary>
    /// Strongly Typed hubs
    /// server -de yazilacaq methodlarin adlarinin sehv yazilmasi ehtimalini
    /// aradan qaldirmaq ucun istifade edilecek methodlari interface cixarmaliyiq
    /// </summary>
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task UserJoined(string connectionId);
        Task UserLeaved(string connectionId);
        Task ReceiveMessage(string message);
    }
}
