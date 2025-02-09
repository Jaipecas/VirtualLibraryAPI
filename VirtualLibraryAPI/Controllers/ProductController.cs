using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VirtualLibrary.Application.Features;

namespace VirtualLibraryAPI.Controllers
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

        [HttpPost]
        public async Task<ActionResult<Unit>> AddProduct(AddProductRequest data)
        {
            return await _mediator.Send(data);
        }
    }
}
