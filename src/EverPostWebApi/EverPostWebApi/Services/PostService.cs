using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.Commons;
using EverPostWebApi.DTOs;
using EverPostWebApi.Repository;

namespace EverPostWebApi.Services
{
    public class PostService : IPostService<Post>
    {

        private readonly IRepository<Post,PostGetDto,PostCreateDto> _repository;
        public PostService([FromKeyedServices("PostRepositoryINJ")]IRepository<Post, PostGetDto, PostCreateDto> repository)
        {
            _repository = repository;
        }
        public Task<IEnumerable<Post>> GetAllPosts(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPost(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Post> AddPost(UploadImage imageToUpload, PostCreateDto postToCreate)
        {
            
        }

        public Task<Post> DeletePost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> EditPost(int id)
        {
            throw new NotImplementedException();
        }

    }
}
