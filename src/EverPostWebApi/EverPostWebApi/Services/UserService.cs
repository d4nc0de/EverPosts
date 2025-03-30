using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.Commons;
using EverPostWebApi.DTOs;
using Microsoft.EntityFrameworkCore;
using EverPostWebApi.Repository;

namespace EverPostWebApi.Services
{
    public class UserService : IUserService<User>
    {
        private readonly Utilities _utilities;
        private readonly IRepository<User, LoginDto,UserDto> _repository;

        public UserService( Utilities utilities,[FromKeyedServices("UserRepositoryINJ")] IRepository<User, LoginDto,UserDto> repository)
        {
            _utilities = utilities;
            _repository = repository;
        }
        public async Task<bool> RegisterUser(UserDto userDto)
        {
            userDto.Pass = _utilities.encryptSHA256(userDto.Pass);
            var userInserted = await _repository.Add(userDto);
            if (userInserted.UserId != 0)
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
            //var userFind = await _everPostContext.Users.Where( u => u.Mail == loginDto.Mail && u.Pass == _utilities.encryptSHA256(loginDto.Pass) && u.Status == "ACT").FirstOrDefaultAsync();
            loginDto.Pass = _utilities.encryptSHA256(loginDto.Pass);
            var userFind = await _repository.GetByFilter(loginDto);

            return userFind;
        }

        public async Task<string> GenerateJWT(User user) 
        {
            return _utilities.GenerateJWT(user);
        }

    }
}
