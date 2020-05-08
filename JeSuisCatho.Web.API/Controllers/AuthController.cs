using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JeSuisCatho.Web.API.Core.Services;
using JeSuisCatho.Web.API.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JeSuisCatho.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService )
        {
            _userService = userService;
        }
        // /api/auth/jisajili
       
        [HttpPost("/api/auth/register")]
        public async Task<IActionResult> RegisterAsync ([FromBody]RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);
                if (result.IsSuccess)
                    return Ok(result); // Status code 200
                return BadRequest(result);
            }
            return BadRequest("Some properties are not valid"); // Status code 400

        }
        // /api/auth/login

        [HttpPost("/api/auth/login")]
        public async Task<IActionResult> LoginAsync ([FromBody]LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);
                if (result.IsSuccess)
                    return Ok(result); // Status code 200
                return BadRequest(result);
            }

            return BadRequest("Some Properties are not valid");
        }


       
    }
}