using EverPostWebApi.Commons;
using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.DTOs;
using EverPostWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EverPostWebApi.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IUserService<User> _userService;
        public AccessController( IUserService<User> userService)
        {
            _userService = userService;
        }

        [HttpGet("Exception")]
        public async Task<ActionResult> ThrowException() 
        {
            throw new Exception("tst");
        }


        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(UserDto userDto)
        {
            var Result = await _userService.RegisterUser(userDto);
            if (!Result)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var userFind = await _userService.Login(loginDto);

            if (userFind == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            }
            else 
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _userService.GenerateJWT(userFind), userFind.UserName });
            }
        }
    }
}
