namespace EverPostWebApi.Repository
{
    public interface IRepository<Tentity,Tg,Tin>
    {
        Task<IEnumerable<Tentity>> Get();
        Task<Tentity> GetById(int id );
        Task<Tentity> GetByFilter(Tg dto);
        Task<Tentity> Add(Tin dto);
        Task<Tentity> Update(Tentity entity);
        Task<Tentity> Delete(int id);
    }
}
