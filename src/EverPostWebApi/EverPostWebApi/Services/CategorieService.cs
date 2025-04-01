
using EverPostWebApi.DTOs;
using EverPostWebApi.Repository;

namespace EverPostWebApi.Services
{
    public class CategorieService : ICategorieService<Categorie>
    {
        private readonly IRepository<Categorie, Categorie, Categorie, Categorie> _repository;
        public CategorieService([FromKeyedServices("CategorieRepositoryINJ")] IRepository<Categorie, Categorie, Categorie, Categorie> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Categorie>> GetCategories()
        {
            try
            {
                var categories = await _repository.Get();
                if (categories == null || categories.Count() == 0) 
                {
                    return null;
                }
                return categories;
            }
            catch (Exception ex) 
            {
                throw new Exception("Ha ocurrido un error obteniendo las categorias: " + ex.Message);
            }
        }
    }
}
