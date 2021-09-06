using Microsoft.AspNetCore.Mvc;
using System;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;
using StoreWebAPI.Data;
using MediatR;
using StoreWebAPI.Features.StoreFeatures.Queries;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetCurrentTime()
        {
            return Ok(DateTime.Now.ToString("T"));
        }
        
    }
}
