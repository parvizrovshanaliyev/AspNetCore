using CQRSWithMediatRExample.DAL.CQRS.Commands.Response;
using MediatR;

namespace CQRSWithMediatRExample.DAL.CQRS.Commands.Request
{
    public class CreateProductCommandRequest : IRequest<CreateProductCommandResponse>
    {
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
