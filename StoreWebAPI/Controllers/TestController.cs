using Microsoft.AspNetCore.Mvc;
using System;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Data;

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
        public string GetCurrentTime()
        {
            //var lst = repository.GetAll();

            return DateTime.Now.ToString("T");
        }
        /// <summary>
        /// only for test...
        /// need to remove!
        /// </summary>
        private readonly IRepository<Store> repository;
        public TestController(StoreDB db)
        {
            repository = new RepositoryBase<Store>(db);
        }

    }
}
