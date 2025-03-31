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
        public async Task<bool> AddPost(UploadImage imageToUpload, PostCreateDto postToCreate)
        {
            var Route = string.Empty;
            if (imageToUpload.Archivo.Length > 0) 
            {
                var ArchiveName = Guid.NewGuid().ToString() + ".jpg";
                Route = $"Uploads/{ArchiveName}";
                using (var stream = new FileStream(Route, FileMode.Create)) 
                {
                    await imageToUpload.Archivo.CopyToAsync(stream);
                }
            }
            postToCreate.Route = Route;
            var PostCreated = await _repository.Add(postToCreate);
            
            if (PostCreated != null)
            {
                foreach (Categorie categorie in postToCreate.Categories)
                {
                    await _repository.AddRelation(PostCreated.PostId, categorie.CategorieId);
                }
                return true;
            }
            else
            {
                return false;
            }
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
