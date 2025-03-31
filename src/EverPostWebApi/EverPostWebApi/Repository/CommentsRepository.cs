using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EverPostWebApi.Repository
{
    public class CommentsRepository : IRepository<Comment, Comment, Comment, Comment>
    {
        private readonly EverPostContext _everPostContext;
        public CommentsRepository(EverPostContext Dbcontext)
        {
            _everPostContext = Dbcontext;

        }
        public async Task<IEnumerable<Comment>> GetPaginated(int pageNumber, int PageSize)
        {
            var Coments = await _everPostContext.Comments.FromSqlInterpolated($"EXEC Sp_GetCommentsPagined ,{pageNumber},{PageSize}").ToListAsync();
            return Coments;
        }
        public async Task<IEnumerable<Comment>> GetPaginatedFilter(int filterId, int pageNumber, int PageSize) 
        {
            var Coments = await _everPostContext.Comments.FromSqlInterpolated($"EXEC Sp_GetCommentsPagined {filterId},{pageNumber},{PageSize}").ToListAsync();
            return Coments;
        }
        public async Task<Comment> Add(Comment comment)
        {
            var Coments = await _everPostContext.Comments.FromSqlInterpolated($"EXEC Sp_CreateComment {comment.Content},{comment.PostId},{comment.UserId}").ToListAsync();
            return Coments.FirstOrDefault();
        }

        public Task<RelPostCategorie> AddRelation(int obj1, int obj2)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Comment> GetByFilter(Comment comment)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Update(Comment entity)
        {
            throw new NotImplementedException();
        }
    }
}
