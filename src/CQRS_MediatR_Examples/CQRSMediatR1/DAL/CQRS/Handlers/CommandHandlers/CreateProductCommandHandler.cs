using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSMediatR1.CQRS.Commands.Request;
using CQRSMediatR1.CQRS.Commands.Response;

namespace CQRSMediatR1.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler
    {
        public CreateProductCommandResponse CreateProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            var id = Guid.NewGuid();
            //ApplicationDbContext.ProductList.Add(new()
            //{
            //    Id = id,
            //    Name = createProductCommandRequest.Name,
            //    Price = createProductCommandRequest.Price,
            //    Quantity = createProductCommandRequest.Quantity,
            //    CreateTime = DateTime.Now
            //});
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = id
            };
        }
    }
}
