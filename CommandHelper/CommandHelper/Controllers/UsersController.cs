using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandHelper.DtoModels;
using CommandHelper.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;

        public UsersController(UserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO model)
        {
            var token = userService.Register(model);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
            return Ok(token);
        }
        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO model)
        {
            var token = userService.Login(model);
            if (string.IsNullOrEmpty(token))
            {
                return BadRequest();
            }
            return Ok(token);
        }
    }
}