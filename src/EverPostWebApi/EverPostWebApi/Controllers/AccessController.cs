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
        public async Task<ActionResult<BaseResponse<bool>>> RegisterUser(UserDto userDto)
        {
            var result = await _userService.RegisterUser(userDto);
            var response = new BaseResponse<bool>
            {
                Success = result,
                Message = result ? "Usuario registrado exitosamente." : "Error al registrar el usuario.",
                Data = result
            };

            if (!result)
            {
                response.Errors.Add("No se pudo completar el registro.");
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<BaseResponse<string>>> Login(LoginDto loginDto)
        {
            var userFind = await _userService.Login(loginDto);
            var response = new BaseResponse<string>();

            if (userFind == null)
            {
                response.Success = false;
                response.Message = "Credenciales incorrectas.";
                response.Data = "";
                response.Errors.Add("Usuario o contraseña incorrectos.");
            }
            else
            {
                response.Success = true;
                response.Message = "Inicio de sesión exitoso.";
                response.Data = await _userService.GenerateJWT(userFind);
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
