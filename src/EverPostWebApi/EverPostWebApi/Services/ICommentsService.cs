using EverPostWebApi.DTOs;

namespace EverPostWebApi.Services
{
    public interface ICommentsService<C, Cp, Ci>
    {
        Task<Cp> GetCommentsPaginated(PaginatorDto paginatorDto);
        Task<C> AddComment(Ci comment);

    }
}
