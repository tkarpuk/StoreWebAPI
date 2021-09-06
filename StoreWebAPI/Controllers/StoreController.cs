using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Features.StoreFeatures.Queries;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Features.StoreFeatures.Commands;
using AutoMapper;
using System.Collections.Generic;
using StoreWebAPI.Models.View;
using Microsoft.AspNetCore.Authorization;

namespace StoreWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
         private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public StoreController(IMediator mediator, IMapper mapper)
        {
            (_mediator, _mapper) = (mediator, mapper);
        }

        /// <summary>
        /// Get list of all stores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var list = await _mediator.Send(new GetStoresQuery());
            var listView = _mapper.Map<List<StoreView>>(list);
            return Ok(listView);
        }

        /// <summary>
        /// Get store by Id (int)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetStoreById")]
        public async Task<IActionResult> GetStoreById(int Id)
        {
            var item = await _mediator.Send(new GetStoreByIdQuery(Id));
            var itemView = _mapper.Map<StoreView>(item);
            return Ok(itemView);
        }

        /// <summary>
        /// Create new store
        /// </summary>
        /// <param name="storeView"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStore(StoreView storeView)
        {
            var store = _mapper.Map<Store>(storeView);
            await _mediator.Send(new AddStoreCommand(store));
            return StatusCode(201);
        }

        /// <summary>
        /// Delete store by Id (int)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteStoreById(int Id)
        {
            await _mediator.Send(new DeleteStoreCommand(Id));
            return StatusCode(201);
        }

        /// <summary>
        /// Update current store
        /// </summary>
        /// <param name="storeView"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStore(StoreView storeView)
        {
            var store = _mapper.Map<Store>(storeView);
            await _mediator.Send(new UpdateStoreCommand(store));
            return StatusCode(201);
        }
        
    }
}
