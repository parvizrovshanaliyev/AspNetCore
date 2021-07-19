using System;
using CQRSWithoutMediatRExample.DAL.CQRS.Commands.Request;
using CQRSWithoutMediatRExample.DAL.CQRS.Commands.Response;
using CQRSWithoutMediatRExample.DAL.Entities;

namespace CQRSWithoutMediatRExample.DAL.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler
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
    }
}
