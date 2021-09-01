using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Features.ProductFeatures.Queries;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Features.ProductFeatures.Commands;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var list = await mediator.Send(new GetProductsQuery());
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var item = await mediator.Send(new GetProductByIdQuery(Id));
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await mediator.Send(new AddProductCommand(product));
            return StatusCode(201);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductById(int Id)
        {
            await mediator.Send(new DeleteProductCommand(Id));
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStore(Product product)
        {
            await mediator.Send(new UpdateProductCommand(product));
            return StatusCode(201);
        }
    }
}
