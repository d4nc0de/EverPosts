using EverPostWebApi.Commons;
using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.DTOs;
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
        private readonly EverPostContext _everPostContext;
        private readonly Utilities _utilities;
        public AccessController(EverPostContext everPostContext, Utilities utilities)
        {
            _everPostContext = everPostContext;
            _utilities = utilities;
        }

        [HttpGet("Exception")]
        public async Task<ActionResult> ThrowException() 
        {
            throw new Exception("tst");
        }


        [HttpPost("Register")]
        public async Task<ActionResult> RegisterUser(UserDto objeto)
        {
            var modeloUser = new User
            {
                UserName = objeto.Name,
                Mail = objeto.Mail,
                Pass = _utilities.encryptSHA256(objeto.Pass),
                Status = "ACT"
            };
            await _everPostContext.Users.AddAsync(modeloUser);
            await _everPostContext.SaveChangesAsync();

            if (modeloUser.UserId != 0)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto objeto)
        {
            var userFind = await _everPostContext.Users.Where(
                u => u.Mail == objeto.Mail && u.Pass == _utilities.encryptSHA256(objeto.Pass)).FirstOrDefaultAsync();

            if (userFind == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            }
            else 
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilities.GenerateJWT(userFind) });
            }
        }
    }
}
