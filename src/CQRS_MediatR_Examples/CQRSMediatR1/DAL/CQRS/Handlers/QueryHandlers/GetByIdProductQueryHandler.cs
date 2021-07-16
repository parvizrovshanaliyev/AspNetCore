using System.Linq;
using CQRSMediatR1.CQRS.Queries.Request;
using CQRSMediatR1.CQRS.Queries.Response;

namespace CQRSMediatR1.DAL.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler
    {
        private readonly AppDbContext _dbContext;

        public GetByIdProductQueryHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public GetByIdProductQueryResponse GetByIdProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.ProductID == id);
            return new GetByIdProductQueryResponse
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                CreateTime = product.CreatedDate
            };
        }
    }
}