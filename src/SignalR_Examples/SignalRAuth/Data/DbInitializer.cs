using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRAuth.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SignalRAuthDB context)
        {
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
    }

}
