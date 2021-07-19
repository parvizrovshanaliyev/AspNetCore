using System.Linq;
using CQRSMediatR1.CQRS.Commands.Request;
using CQRSMediatR1.CQRS.Commands.Response;
using CQRSMediatR1.DAL;

namespace CQRSMediatR1.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler
    {
        private readonly AppDbContext _dbContext;

        public DeleteProductCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public DeleteProductCommandResponse DeleteProduct(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            var deleteProduct = _dbContext.Products.FirstOrDefault(p => p.ProductID == deleteProductCommandRequest.Id);
            _dbContext.Products.Remove(deleteProduct);
            _dbContext.SaveChanges();
            return new DeleteProductCommandResponse
            {
                IsSuccess = true
            };
        }
    }
}