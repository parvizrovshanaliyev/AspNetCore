using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSWithMediatRExample.DAL.CQRS.Queries.Request;
using CQRSWithMediatRExample.DAL.CQRS.Queries.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRExample.DAL.CQRS.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
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

        #region Implementation of IRequestHandler<in GetAllProductQueryRequest,List<GetAllProductQueryResponse>>

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.Select(product => new GetAllProductQueryResponse
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                CreateTime = product.CreatedDate
            }).ToListAsync();
        }

        #endregion
    }
}
