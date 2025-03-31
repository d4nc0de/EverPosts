using EverPostWebApi.DTOs;

namespace EverPostWebApi.Services
{
    public interface IPostService<P,Pget>
    {
        public Task<P> GetPost(int id);
        public Task<Pget> GetAllPosts(int pageNumber, int PageSize);
        public Task<P> AddPost(UploadImage imageToUpload, PostCreateDto postToCreate );
        public Task<bool> DeletePost(int id);
        public Task<bool> EditPost(PostUpdateDto postUpdateDto);
        
    }
}
