
using ChannelMonitoring.Utils;
using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EverPostWebApi.Repository
{
    public class UserRepository : IRepository<User, LoginDto, UserDto, User>
    {
        private readonly EverPostContext _everPostContext;
        private readonly ADOHelper _helper;
        public UserRepository(EverPostContext Dbcontext ,ADOHelper helper)
        {
            _everPostContext = Dbcontext;
            _helper = helper;
        }
        public async Task<User> Add(UserDto user)
        {
            var usuarioInserted = await _everPostContext.Users.FromSqlInterpolated($"EXEC Sp_CreateUser {user.Name},{user.Mail},{user.Pass}").ToListAsync();
            return usuarioInserted.FirstOrDefault();
        }
            
        public async Task<User> GetByFilter(LoginDto loginDto)
        {
            var usuarios = await _everPostContext.Users.FromSqlInterpolated($"EXEC Sp_GetUserByCredentials {loginDto.Mail},{loginDto.Pass}").ToListAsync();
            return usuarios.FirstOrDefault();
        }

        public Task<User> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> Get(int pageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
        public Task<RelPostCategorie> AddRelation(int obj1, int obj2) 
        {
            throw new NotImplementedException();
        }
    }
};
