using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSMediatR1.CQRS.Commands.Request;
using CQRSMediatR1.CQRS.Commands.Response;
using CQRSMediatR1.CQRS.Handlers.CommandHandlers;
using CQRSMediatR1.CQRS.Queries.Request;
using CQRSMediatR1.CQRS.Queries.Response;
using CQRSMediatR1.DAL.CQRS.Handlers.QueryHandlers;

namespace CQRSMediatR1.Controllers
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
