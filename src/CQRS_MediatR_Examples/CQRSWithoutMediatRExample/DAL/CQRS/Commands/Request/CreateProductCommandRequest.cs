namespace CQRSWithoutMediatRExample.DAL.CQRS.Commands.Request
{
    public class CreateProductCommandRequest
    {
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
