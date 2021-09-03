using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Features.StoreFeatures.Queries;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Features.StoreFeatures.Commands;
using AutoMapper;
using System.Collections.Generic;
using StoreWebAPI.Models.DTO;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
         private readonly IMediator mediator;
        private readonly IMapper mapper;

        public StoreController(IMediator mediator, IMapper mapper)
        {
            (this.mediator, this.mapper) = (mediator, mapper);
        }

        /// <summary>
        /// Get list of all stores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var list = await mediator.Send(new GetStoresQuery());
            var listDTO = mapper.Map<List<StoreDTO>>(list);
            return Ok(listDTO);
        }

        /// <summary>
        /// Get store by Id (int)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetStoreById")]
        public async Task<IActionResult> GetStoreById(int Id)
        {
            var item = await mediator.Send(new GetStoreByIdQuery(Id));
            var itemDTO = mapper.Map<StoreDTO>(item);
            return Ok(itemDTO);
        }

        /// <summary>
        /// Create new store
        /// </summary>
        /// <param name="storeDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStore(StoreDTO storeDTO)
        {
            var store = mapper.Map<Store>(storeDTO);
            await mediator.Send(new AddStoreCommand(store));
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
            await mediator.Send(new DeleteStoreCommand(Id));
            return StatusCode(201);
        }

        /// <summary>
        /// Update current store
        /// </summary>
        /// <param name="storeDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStore(StoreDTO storeDTO)
        {
            var store = mapper.Map<Store>(storeDTO);
            await mediator.Send(new UpdateStoreCommand(store));
            return StatusCode(201);
        }
        
    }
}
