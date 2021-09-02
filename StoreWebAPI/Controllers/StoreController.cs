using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Features.StoreFeatures.Queries;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Features.StoreFeatures.Commands;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IMediator mediator;
        public StoreController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Get list of all stores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var list = await mediator.Send(new GetStoresQuery());
            return Ok(list);
        }

        /// <summary>
        /// Get store by Id (int)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetStoreById(int Id)
        {
            var item = await mediator.Send(new GetStoreByIdQuery(Id));
            return Ok(item);
        }

        /// <summary>
        /// Create new store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStore(Store store)
        {
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
        /// <param name="store"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateStore(Store store)
        {
            await mediator.Send(new UpdateStoreCommand(store));
            return StatusCode(201);
        }
        */
    }
}
