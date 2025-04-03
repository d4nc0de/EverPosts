using EverPostWebApi.DTOs;

namespace EverPostWebApi.Services
{
    public interface IPostService<P,Pget>
    {
        public Task<P> GetPost(int id);
        public Task<Pget> GetAllPosts(PaginatorDto paginatorDto);
        public Task<P> AddPost(IFormFile imageToUpload, PostCreateDto postToCreate );
        public Task<bool> DeletePost(int id);
        public Task<bool> EditPost(PostUpdateDto postUpdateDto);
        
    }
}
