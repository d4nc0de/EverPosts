namespace EverPostWebApi.Services
{
    public interface ICategorieService<T>
    {
        Task<IEnumerable<T>> GetCategories();
    }
}
