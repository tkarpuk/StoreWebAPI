using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Features.ProductFeatures.Queries;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Features.ProductFeatures.Commands;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using StoreWebAPI.Models.DTO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace StoreWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ProductController(IConfiguration config, IMediator mediator, IMapper mapper)
        {
            (this.mediator, this.configuration, this.mapper) = (mediator, config, mapper);            
        }

        /// <summary>
        /// Gel list of all products by page number
        /// default page size = 10
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpGet("{storeId:int}/{page:int}", Name = "GetProducts")]
        public async Task<IActionResult> GetProducts(int storeId, int page = 1)
        {           
            int pageSize = configuration.GetValue<int>("PageSettings:PageSize");

            var pageItems = await mediator.Send(new GetProductsQuery(storeId, page, pageSize));
            var pageItemsDTO = mapper.Map<List<ProductDTO>>(pageItems);

            return Ok(pageItemsDTO);
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
            var itemDTO = mapper.Map<ProductDTO>(item);
            return Ok(itemDTO);
        }

        /// <summary>
        /// Create product in DB
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            var product = mapper.Map<Product>(productDTO);
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
        /// <param name="productDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStore(ProductDTO productDTO)
        {
            var product = mapper.Map<Product>(productDTO);
            await mediator.Send(new UpdateProductCommand(product));
            return StatusCode(201);
        }
    }
}
