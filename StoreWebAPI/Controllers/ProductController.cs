using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Features.ProductFeatures.Queries;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Features.ProductFeatures.Commands;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using StoreWebAPI.Models.View;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace StoreWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductController(IConfiguration config, IMediator mediator, IMapper mapper)
        {
            (_mediator, _configuration, _mapper) = (mediator, config, mapper);            
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
            int pageSize = _configuration.GetValue<int>("PageSettings:PageSize");

            var pageItems = await _mediator.Send(new GetProductsQuery(storeId, page, pageSize));
            var pageItemsView = _mapper.Map<List<ProductView>>(pageItems);

            return Ok(pageItemsView);
        }
       
        /// <summary>
        /// Get one product by Id (int)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("Id/{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            var item = await _mediator.Send(new GetProductByIdQuery(Id));
            var itemView = _mapper.Map<ProductView>(item);
            return Ok(itemView);
        }

        /// <summary>
        /// Create product in DB
        /// </summary>
        /// <param name="productView"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductView productView)
        {
            var product = _mapper.Map<Product>(productView);
            await _mediator.Send(new AddProductCommand(product));
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
            await _mediator.Send(new DeleteProductCommand(Id));
            return StatusCode(201);
        }

        /// <summary>
        /// Update current product in DB
        /// </summary>
        /// <param name="productView"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStore(ProductView productView)
        {
            var product = _mapper.Map<Product>(productView);
            await _mediator.Send(new UpdateProductCommand(product));
            return StatusCode(201);
        }
    }
}
