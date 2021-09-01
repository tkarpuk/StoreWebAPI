using Microsoft.AspNetCore.Mvc;
using System;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Data;
using MediatR;
using StoreWebAPI.Features.StoreFeatures.Queries;
using System.Threading.Tasks;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// Return current time for testing application
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> GetCurrentTime()
        {
            var lst = await mediator.Send(new GetStoresQuery());

            return Ok(DateTime.Now.ToString("T"));
        }
        /// <summary>
        /// only for test...
        /// need to remove!
        /// </summary>
        //private readonly IRepository<Store> repository;
        //public TestController(StoreDB db)
        //{
        //    repository = new RepositoryBase<Store>(db);
        //}
        private readonly IMediator mediator;
        public TestController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
