using EverPostWebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EverPostWebApi.Services
{
    public interface IUserService<U>
    {
        public Task<bool> RegisterUser(UserDto objeto);
        public Task<U> Login(LoginDto objeto);
        public Task<string> GenerateJWT(User modelo);
    }
}
