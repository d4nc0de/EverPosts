using EverPostWebApi.DTOs;

namespace EverPostWebApi.Services
{
    public interface IPostService<P>
    {
        public Task<P> GetPost(int id);
        public Task<IEnumerable<P>> GetAllPosts(int id);
        public Task<bool> AddPost(UploadImage imageToUpload, PostCreateDto postToCreate );
        public Task<P> DeletePost(int id);
        public Task<P> EditPost(int id);
        
    }
}
