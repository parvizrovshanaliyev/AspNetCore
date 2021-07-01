using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinIOExample1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MinIODbContext context)
        {
            context.Database.EnsureCreated();

            context.SaveChanges();
        }
    }
}
