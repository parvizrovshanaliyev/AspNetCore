using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Application.Interfaces.Repositories;
using ProductApp.Domain.Entities;

namespace ProductApp.Persistence.Repositories
{
    public class  ProductRepository : GenericRepository<Product>
    {
    }
}
