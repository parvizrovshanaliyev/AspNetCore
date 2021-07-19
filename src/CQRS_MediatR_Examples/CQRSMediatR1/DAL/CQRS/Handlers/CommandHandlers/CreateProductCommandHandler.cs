using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSMediatR1.CQRS.Commands.Request;
using CQRSMediatR1.CQRS.Commands.Response;
using CQRSMediatR1.DAL;
using CQRSMediatR1.DAL.Entities;

namespace CQRSMediatR1.CQRS.Handlers.CommandHandlers
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
