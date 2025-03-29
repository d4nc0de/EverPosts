using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.Commons;
using EverPostWebApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EverPostWebApi.Services
{
    public class UserService : IUserService<User>
    {
        private readonly EverPostContext _everPostContext;
        private readonly Utilities _utilities;

        public UserService(EverPostContext everPostContext, Utilities utilities)
        {
            _everPostContext = everPostContext;
            _utilities = utilities;
        }
        public async Task<bool> RegisterUser(UserDto userDto)
        {
            var modeloUser = new User
            {
                UserName = userDto.Name,
                Mail = userDto.Mail,
                Pass = _utilities.encryptSHA256(userDto.Pass),
                Status = "ACT"
            };
            await _everPostContext.Users.AddAsync(modeloUser);
            await _everPostContext.SaveChangesAsync();

            if (modeloUser.UserId != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> Login(LoginDto loginDto)
        {
            var userFind = await _everPostContext.Users.Where(
                u => u.Mail == loginDto.Mail && u.Pass == _utilities.encryptSHA256(loginDto.Pass)).FirstOrDefaultAsync();
            return userFind;
        }

        public async Task<string> GenerateJWT(User user) 
        {
            return _utilities.GenerateJWT(user);
        }

    }
}
