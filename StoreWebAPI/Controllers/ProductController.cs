using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Features.ProductFeatures.Queries;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Features.ProductFeatures.Commands;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IMediator mediator;
        public ProductController(IConfiguration config, IMediator mediator)
        {
            this.mediator = mediator;
            this.configuration = config;
        }

        /// <summary>
        /// Gel list of all products
        /// default page size = 10
        /// </summary>
        /// <returns></returns>
        [HttpGet("{page:int}", Name = "GetProducts")]
        public async Task<IActionResult> GetProducts(int page = 1)
        {
           
            int pageSize = configuration.GetValue<int>("PageSettings:PageSize");

            var listAll = await mediator.Send(new GetProductsQuery());

            var pageItems = await Task.Run(() =>
            {
                var count = listAll.Count();
                if (count < pageSize)
                    return listAll;

                return listAll.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            });

            
            return Ok(pageItems);
        }
       
        /// <summary>
        /// Get one product by Id (int)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("Id/{id:int}", Name = "GetProductById")]
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
