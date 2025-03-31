
using ChannelMonitoring.Utils;
using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EverPostWebApi.Repository
{
    public class PostRepository : IRepository<Post, PostGetDto , PostCreateDto>
    {
        private readonly EverPostContext _everPostContext;
        public PostRepository(EverPostContext Dbcontext)
        {
            _everPostContext = Dbcontext;

        }
        public Task<IEnumerable<Post>> Get()
        {
            throw new NotImplementedException();
        }
        public Task<Post> GetById(int id)
        {
            throw new NotImplementedException();
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

        public Task<Post> Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public Task<Post> Delete(int id)
        {
            throw new NotImplementedException();
        }



    }
}
