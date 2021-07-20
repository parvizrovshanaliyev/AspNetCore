using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSWithMediatRExample.DAL.CQRS.Queries.Request;
using CQRSWithMediatRExample.DAL.CQRS.Queries.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRExample.DAL.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
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

        #region Implementation of IRequestHandler<in GetByIdProductQueryRequest,GetByIdProductQueryResponse>

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product =
                await _dbContext.Products
                    .SingleOrDefaultAsync(p => p.ProductID == request.Id);

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

        #endregion
    }
}