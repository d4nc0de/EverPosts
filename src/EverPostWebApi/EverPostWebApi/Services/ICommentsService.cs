using EverPostWebApi.DTOs;

namespace EverPostWebApi.Services
{
    public interface ICommentsService<C, Cp>
    {
        Task<Cp> GetCommentsPaginated(PaginatorDto paginatorDto);
        Task<C> AddComment(C comment);

    }
}
