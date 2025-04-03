using EverPostWebApi.Commons.Dbcontext;
using Microsoft.EntityFrameworkCore;

namespace EverPostWebApi.Repository
{
    public class CategorieRepository: IRepository<Categorie, Categorie, Categorie, Categorie>
    {
        private readonly EverPostContext _everPostContext;
        public CategorieRepository(EverPostContext Dbcontext)
        {
            _everPostContext = Dbcontext;

        }
        public async Task<IEnumerable<Categorie>> Get()
        {
            var Coments = await _everPostContext.Categories.FromSqlInterpolated($"EXEC Sp_GetCategories").ToListAsync();
            return Coments;
        }

        public Task<Categorie> Add(Categorie dto)
        {
            throw new NotImplementedException();
        }

        public Task<RelPostCategorie> AddRelation(int obj1, int obj2)
        {
            throw new NotImplementedException();
        }

        public Task<Categorie> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Categorie> GetByFilter(Categorie dto)
        {
            throw new NotImplementedException();
        }

        public Task<Categorie> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categorie>> GetPaginated(int pageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categorie>> GetPaginatedFilter(int filterId, int pageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Categorie> Update(Categorie entity)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Categorie>> GetByRelation(int id) 
        {
            throw new NotImplementedException();
        }
    }
}
