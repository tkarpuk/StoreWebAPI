using Microsoft.AspNetCore.Mvc;
using StoreWebAPI.Auth;
using StoreWebAPI.Models.Service;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace StoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger logger;
        public AccountController(ILogger<AccountController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Method for getting authorization token
        /// use "1" as Login and Password for test. 
        /// </summary>
        /// <param name="login">use "1"</param>
        /// <param name="password">use "1"</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("/login")]
        public IActionResult Login(string login = "1", string password = "1")
        {
            var checker = new LoginChecker(login, password);
            Person person = checker.GetPerson();
            if (person == null)
            {
                logger.LogWarning($"Unknown user {login}.");
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var jwt = new PersonJWT(person);

            return Ok(JsonSerializer.Serialize(jwt.CreateJWT()));
        }
    }
}
