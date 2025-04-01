
using EverPostWebApi.DTOs;
using EverPostWebApi.Repository;

namespace EverPostWebApi.Services
{
    public class CommentsService : ICommentsService<Comment, DataPaginatedDTO<Comment>, CommentCreateDto>
    {
        private readonly IRepository<Comment, Comment, CommentCreateDto, Comment> _repository;
        public CommentsService([FromKeyedServices("CommentRepositoryINJ")] IRepository<Comment, Comment, CommentCreateDto, Comment> repository)
        {
            _repository = repository;
        }
        public async Task<DataPaginatedDTO<Comment>> GetCommentsPaginated(PaginatorDto paginatorDto)
        {
            try
            {
                var comments = await _repository.GetPaginatedFilter(paginatorDto.filterId,paginatorDto.Page,paginatorDto.PageSize);
                if (comments.Count() == 0 || comments.Count() == null)
                {
                    return null;
                }

                var commentsPaginatedDto = new DataPaginatedDTO<Comment>
                {
                    Data = comments.ToList(),
                    TotalRecords = comments.Count(),
                    Page = paginatorDto.Page,
                    PageSize = paginatorDto.PageSize,
                    TotalPages = comments.Count() / paginatorDto.Page
                };
                return commentsPaginatedDto;
            }
            catch (Exception ex) 
            {
                throw new Exception("Ha ocurrido un error obteniendo los comentarios: " + ex.Message);
            }
        }
        public Task<Comment> AddComment(CommentCreateDto comment)
        {
            try 
            {
                var commnetInserted = _repository.Add(comment);

                if (commnetInserted != null) 
                {
                    return commnetInserted;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Ha ocurrido un error Insertando el comentario: " + ex.Message);
            }
            
        }

    }
}
