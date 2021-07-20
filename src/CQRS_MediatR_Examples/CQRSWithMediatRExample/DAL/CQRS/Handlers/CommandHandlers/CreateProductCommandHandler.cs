using System;
using System.Threading;
using System.Threading.Tasks;
using CQRSWithMediatRExample.DAL.CQRS.Commands.Request;
using CQRSWithMediatRExample.DAL.CQRS.Commands.Response;
using CQRSWithMediatRExample.DAL.Entities;
using MediatR;

namespace CQRSWithMediatRExample.DAL.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly AppDbContext _dbContext;

        public CreateProductCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CreateProductCommandResponse CreateProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            var product = new Product()
            {
                ProductName = createProductCommandRequest.ProductName,
                UnitPrice = createProductCommandRequest.UnitPrice,
                UnitsInStock = createProductCommandRequest.UnitsInStock,
                CreatedDate = DateTime.Now
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.ProductID
            };
        }

        #region Implementation of IRequestHandler<in CreateProductCommandRequest,CreateProductCommandResponse>

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                ProductName = request.ProductName,
                UnitPrice = request.UnitPrice,
                UnitsInStock = request.UnitsInStock,
                CreatedDate = DateTime.Now
            };

            await _dbContext.Products.AddAsync(product);
            await  _dbContext.SaveChangesAsync();
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = product.ProductID
            };
        }

        #endregion
    }
}
