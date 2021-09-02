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

        /// <summary>
        /// Gel list of all products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var list = await mediator.Send(new GetProductsQuery());
            return Ok(list);
        }

        /// <summary>
        /// Get one product by Id (int)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var item = await mediator.Send(new GetProductByIdQuery(Id));
            return Ok(item);
        }

        /// <summary>
        /// Create product in DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            await mediator.Send(new AddProductCommand(product));
            return StatusCode(201);
        }

        /// <summary>
        /// Delete product by Id (int)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteProductById(int Id)
        {
            await mediator.Send(new DeleteProductCommand(Id));
            return StatusCode(201);
        }

        /// <summary>
        /// Update current product in DB
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStore(Product product)
        {
            await mediator.Send(new UpdateProductCommand(product));
            return StatusCode(201);
        }
    }
}
