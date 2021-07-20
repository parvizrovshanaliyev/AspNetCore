using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CQRSWithMediatRExample.DAL.CQRS.Commands.Request;
using CQRSWithMediatRExample.DAL.CQRS.Commands.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRSWithMediatRExample.DAL.CQRS.Handlers.CommandHandlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductCommandResponse>
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

        #region Implementation of IRequestHandler<in DeleteProductCommandRequest,DeleteProductCommandResponse>

        public async Task<DeleteProductCommandResponse> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteProduct = await _dbContext.Products.SingleOrDefaultAsync(p => p.ProductID == request.Id, cancellationToken: cancellationToken);
            _dbContext.Products.Remove(deleteProduct);
            await _dbContext.SaveChangesAsync();
            return new DeleteProductCommandResponse
            {
                IsSuccess = true
            };
        }

        #endregion
    }
}