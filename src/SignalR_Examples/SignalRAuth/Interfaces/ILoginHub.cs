using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignalRAuth.Models;

namespace SignalRAuth.Interfaces
{
    public interface ILoginHub
    {
        Task Login(Token token);
        Task Create(bool result);
    }
}
