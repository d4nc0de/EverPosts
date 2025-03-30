using EverPostWebApi.DTOs;

namespace EverPostWebApi.Services
{
    public interface IPostService<Post>
    {
        public Task<Post> GetPost(int id);
        public Task<IEnumerable<Post>> GetAllPosts(int id);
        public Task<Post> AddPost(UploadImage imageToUpload, PostCreateDto postToCreate );
        public Task<Post> DeletePost(int id);
        public Task<Post> EditPost(int id);
        
    }
}
