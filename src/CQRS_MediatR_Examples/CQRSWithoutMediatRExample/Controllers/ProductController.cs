using System.Collections.Generic;
using CQRSWithoutMediatRExample.DAL.CQRS.Commands.Request;
using CQRSWithoutMediatRExample.DAL.CQRS.Commands.Response;
using CQRSWithoutMediatRExample.DAL.CQRS.Handlers.CommandHandlers;
using CQRSWithoutMediatRExample.DAL.CQRS.Handlers.QueryHandlers;
using CQRSWithoutMediatRExample.DAL.CQRS.Queries.Request;
using CQRSWithoutMediatRExample.DAL.CQRS.Queries.Response;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithoutMediatRExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly DeleteProductCommandHandler _deleteProductCommandHandler;
        private readonly GetAllProductQueryHandler _getAllProductQueryHandler;
        private readonly GetByIdProductQueryHandler _getByIdProductQueryHandler;
        public ProductController(
            CreateProductCommandHandler createProductCommandHandler,
            DeleteProductCommandHandler deleteProductCommandHandler,
            GetAllProductQueryHandler getAllProductQueryHandler,
            GetByIdProductQueryHandler getByIdProductQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getAllProductQueryHandler = getAllProductQueryHandler;
            _getByIdProductQueryHandler = getByIdProductQueryHandler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> allProducts = _getAllProductQueryHandler.GetAllProduct(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            GetByIdProductQueryResponse product = _getByIdProductQueryHandler.GetByIdProduct(id);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = _createProductCommandHandler.CreateProduct(requestModel);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] DeleteProductCommandRequest requestModel)
        {
            DeleteProductCommandResponse response = _deleteProductCommandHandler.DeleteProduct(requestModel);
            return Ok(response);
        }
    }
}
