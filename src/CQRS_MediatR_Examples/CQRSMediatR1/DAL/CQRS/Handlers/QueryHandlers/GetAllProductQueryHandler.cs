using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSMediatR1.CQRS.Queries.Request;
using CQRSMediatR1.CQRS.Queries.Response;

namespace CQRSMediatR1.DAL.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler
    {
        private readonly AppDbContext _dbContext;

        public GetAllProductQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<GetAllProductQueryResponse> GetAllProduct(GetAllProductQueryRequest getAllProductQueryRequest)
        {
            return _dbContext.Products.Select(product => new GetAllProductQueryResponse
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                CreateTime = product.CreatedDate
            }).ToList();
        }
    }
}
