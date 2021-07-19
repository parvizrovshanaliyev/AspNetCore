namespace CQRSWithMediatRExample.DAL.CQRS.Commands.Response
{
    public class CreateProductCommandResponse
    {
        public bool IsSuccess { get; set; }
        public int ProductId { get; set; }
    }
}
