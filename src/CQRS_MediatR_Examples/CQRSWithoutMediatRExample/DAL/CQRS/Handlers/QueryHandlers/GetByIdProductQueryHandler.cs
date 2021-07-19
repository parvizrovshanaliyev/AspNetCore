using System.Linq;
using CQRSWithoutMediatRExample.DAL.CQRS.Queries.Request;
using CQRSWithoutMediatRExample.DAL.CQRS.Queries.Response;

namespace CQRSWithoutMediatRExample.DAL.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler
    {
        private readonly AppDbContext _dbContext;

        public GetByIdProductQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public GetByIdProductQueryResponse GetByIdProduct(GetByIdProductQueryRequest request)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.ProductID == request.Id);

            if (product != null)
                return new GetByIdProductQueryResponse
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice,
                    UnitsInStock = product.UnitsInStock,
                    CreateTime = product.CreatedDate
                };
            return null;
        }
    }
}