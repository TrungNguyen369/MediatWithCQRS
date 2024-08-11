using MediatR;
using MediatWithCQRS.Request;
using Microsoft.AspNetCore.Mvc;

namespace MediatWithCQRS.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return Ok(productId);
        }
    }
}
