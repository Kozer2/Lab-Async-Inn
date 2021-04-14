using Async_Inn.Models.Api;
using Async_Inn.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public UsersController(IUserService userService)
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterData data)
        {
            return Ok();
        }
    }
}
