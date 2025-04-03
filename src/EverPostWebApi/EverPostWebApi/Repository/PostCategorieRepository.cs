
using EverPostWebApi.Commons.Dbcontext;
using Microsoft.EntityFrameworkCore;

namespace EverPostWebApi.Repository
{
    public class PostCategorieRepository : IRepository<RelPostCategorie, RelPostCategorie, RelPostCategorie, RelPostCategorie>
    {
        private readonly EverPostContext _everPostContext;
        public PostCategorieRepository(EverPostContext Dbcontext)
        {
            _everPostContext = Dbcontext;

        }
        public Task<RelPostCategorie> Add(RelPostCategorie dto)
        {
            throw new NotImplementedException();
        }

        public Task<RelPostCategorie> AddRelation(int obj1, int obj2)
        {
            throw new NotImplementedException();
        }

        public Task<RelPostCategorie> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RelPostCategorie>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<RelPostCategorie> GetByFilter(RelPostCategorie dto)
        {
            throw new NotImplementedException();
        }

        public Task<RelPostCategorie> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RelPostCategorie>> GetPaginated(int pageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RelPostCategorie>> GetPaginatedFilter(int filterId, int pageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<RelPostCategorie> Update(RelPostCategorie entity)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<RelPostCategorie>> GetByRelation(int id)
        {
            var Posts = await _everPostContext.RelPostCategories.FromSqlInterpolated($"EXEC Sp_GetCategorieRelation {id}").ToListAsync();
            return Posts;
        }
    }
}
