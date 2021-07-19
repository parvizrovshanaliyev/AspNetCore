using System.Collections.Generic;
using System.Linq;
using CQRSWithoutMediatRExample.DAL.CQRS.Queries.Request;
using CQRSWithoutMediatRExample.DAL.CQRS.Queries.Response;

namespace CQRSWithoutMediatRExample.DAL.CQRS.Handlers.QueryHandlers
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
