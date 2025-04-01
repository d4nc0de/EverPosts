namespace EverPostWebApi.Repository
{
    public interface IRepository<Tentity,Tg,Tin,Te>
    {
        Task<IEnumerable<Tentity>> GetPaginated(int pageNumber, int PageSize);
        Task<IEnumerable<Tentity>> GetPaginatedFilter(int filterId,int pageNumber, int PageSize);
        Task<Tentity> GetById(int id );
        Task<IEnumerable<Tentity>> Get();
        Task<Tentity> GetByFilter(Tg dto);
        Task<Tentity> Add(Tin dto);
        Task<Tentity> Update(Te entity);
        Task<Tentity> Delete(int id);
        Task<RelPostCategorie> AddRelation(int obj1, int obj2);
    }
}
