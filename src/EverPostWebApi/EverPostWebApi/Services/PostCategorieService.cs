
using EverPostWebApi.DTOs;
using EverPostWebApi.Repository;

namespace EverPostWebApi.Services
{
    public class PostCategorieService : IPostCategorie<RelPostCategorie>
    {
        private readonly IRepository<RelPostCategorie, RelPostCategorie, RelPostCategorie, RelPostCategorie> _repository;
        public PostCategorieService([FromKeyedServices("PostCategorieRepositoryINJ")]
        IRepository<RelPostCategorie, RelPostCategorie, RelPostCategorie, RelPostCategorie> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<RelPostCategorie>> GetRelPostCategorie(int id)
        {
            try
            {
                var relPostCategories = await _repository.GetByRelation(id);
                if (relPostCategories.Count() == 0 || relPostCategories == null)
                {
                    return null;
                }
                return relPostCategories;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error obteniendo los comentarios: " + ex.Message);
            }
        }
    }
}
