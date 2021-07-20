using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Persistence.Context;
using ProductApp.Persistence.Repositories;

namespace ProductApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<ProductAppDbContext>(options => options.UseInMemoryDatabase("memoryDb"));

            services.AddTransient<IProductRepository, ProductRepository>();

        }
    }
}
