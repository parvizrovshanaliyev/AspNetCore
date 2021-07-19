using System.Collections.Generic;
using CQRSWithMediatRExample.DAL.CQRS.Commands.Request;
using CQRSWithMediatRExample.DAL.CQRS.Commands.Response;
using CQRSWithMediatRExample.DAL.CQRS.Handlers.CommandHandlers;
using CQRSWithMediatRExample.DAL.CQRS.Handlers.QueryHandlers;
using CQRSWithMediatRExample.DAL.CQRS.Queries.Request;
using CQRSWithMediatRExample.DAL.CQRS.Queries.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSWithMediatRExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetAllProductQueryRequest request)
        {
            var response  = _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute]GetByIdProductQueryRequest request)
        {
            var response = _mediator.Send(request);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCommandRequest request)
        {
            var response = _mediator.Send(request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] DeleteProductCommandRequest request)
        {
            var response = _mediator.Send(request);

            return Ok(response);
        }
    }
}
