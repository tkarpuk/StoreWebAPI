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

        [HttpGet]
        public async Task<IActionResult> GetStores()
        {
            var list = await mediator.Send(new GetStoresQuery());
            return Ok(list);
        }

        [HttpGet]
        public async Task<IActionResult> GetStoreById(int Id)
        {
            var item = await mediator.Send(new GetStoreByIdQuery(Id));
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddStore(Store store)
        {
            await mediator.Send(new AddStoreCommand(store));
            return StatusCode(201);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStoreById(int Id)
        {
            await mediator.Send(new DeleteStoreCommand(Id));
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStore(Store store)
        {
            await mediator.Send(new UpdateStoreCommand(store));
            return StatusCode(201);
        }
    }
}
