namespace EverPostWebApi.Services
{
    public interface IPostCategorie<T>
    {
        Task<IEnumerable<T>> GetRelPostCategorie(int id);
    }
}
