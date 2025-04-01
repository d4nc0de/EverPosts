
using ChannelMonitoring.Utils;
using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EverPostWebApi.Repository
{
    public class PostRepository : IRepository<Post, PostGetDto , PostCreateDto, PostUpdateDto>
    {
        private readonly EverPostContext _everPostContext;
        public PostRepository(EverPostContext Dbcontext)
        {
            _everPostContext = Dbcontext;

        }
        public async Task<IEnumerable<Post>> GetPaginated(int pageNumber,int PageSize)
        {
            var Posts = await _everPostContext.Posts.FromSqlInterpolated($"EXEC Sp_GetPostsPaginated {pageNumber},{PageSize}").ToListAsync();
            return Posts;
        }
        public async Task<Post> GetById(int id)
        {
            var Posts = await _everPostContext.Posts.FromSqlInterpolated($"EXEC Sp_GetPostById {id}").ToListAsync();
            return Posts.FirstOrDefault();
        }
        public Task<Post> GetByFilter(PostGetDto dto)
        {
            throw new NotImplementedException();
        }
        public async Task<Post> Add(PostCreateDto postToCreate)
        {
            var postCreated = await _everPostContext.Posts.FromSqlInterpolated($"EXEC Sp_CreatePost {postToCreate.UserId},{postToCreate.Tittle},{postToCreate.Description},{postToCreate.Route}").ToListAsync();
            return postCreated.FirstOrDefault();
        }
        public async Task<RelPostCategorie> AddRelation(int postId,int categorieId)
        {
            var Relation = await _everPostContext.RelPostCategories.FromSqlInterpolated($"EXEC Sp_CategorieRelation {postId},{categorieId}").ToListAsync();
            return Relation.FirstOrDefault();
        }

        public async Task<Post> Update(PostUpdateDto valuesToUpdate)
        {
            var PostDeleted = await _everPostContext.Posts.FromSqlInterpolated($"EXEC Sp_EditPost {valuesToUpdate.postId},{valuesToUpdate.Tittle}, {valuesToUpdate.Description}").ToListAsync();
            return PostDeleted.FirstOrDefault();
        }

        public async Task<Post> Delete(int id)
        {
            var PostDeleted = await _everPostContext.Posts.FromSqlInterpolated($"EXEC Sp_DeletePost {id}").ToListAsync();
            return PostDeleted.FirstOrDefault();
        }

        public Task<IEnumerable<Post>> GetPaginatedFilter(int filterId, int pageNumber, int PageSize) 
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Post>> Get()
        {
            throw new NotImplementedException();
        }


    }
}
