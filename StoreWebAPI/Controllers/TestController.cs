using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public string GetCurrentTime()
        {
            return DateTime.Now.ToString("T");
        }

    }
}
