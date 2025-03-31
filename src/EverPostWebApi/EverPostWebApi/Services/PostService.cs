using EverPostWebApi.Commons.Dbcontext;
using EverPostWebApi.Commons;
using EverPostWebApi.DTOs;
using EverPostWebApi.Repository;

namespace EverPostWebApi.Services
{
    public class PostService : IPostService<Post,PostsPaginatedDTO>
    {

        private readonly IRepository<Post,PostGetDto,PostCreateDto,PostUpdateDto> _repository;
        public PostService([FromKeyedServices("PostRepositoryINJ")]IRepository<Post, PostGetDto, PostCreateDto, PostUpdateDto> repository)
        {
            _repository = repository;
        }
        public async Task<PostsPaginatedDTO> GetAllPosts(int pageNumber, int PageSize)
        {
            try
            {
                var posts = await _repository.Get(pageNumber, PageSize);
                if (posts.Count() == 0 || posts.Count() == null)
                {
                    return null;
                }

                var postPaginatedDto = new PostsPaginatedDTO
                {
                    Data = posts.ToList(),
                    TotalRecords = posts.Count(),
                    Page = pageNumber,
                    PageSize = PageSize,
                    TotalPages = posts.Count() / PageSize
                };
                return postPaginatedDto;
            }
            catch (Exception ex) 
            {
                throw new Exception("Ah ocurrido un error tratando de añadir el post: " + ex.Message);
            }
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _repository.GetById(id);
            if (post != null) 
            {
                return post;
            }
            return null;
        }
        public async Task<Post> AddPost(UploadImage imageToUpload, PostCreateDto postToCreate)
        {
            try
            {
                var Route = string.Empty;
                var RelativeRoute = string.Empty;
                if (imageToUpload.Archivo.Length > 0)
                {
                    var ArchiveName = Guid.NewGuid().ToString() + ".jpg";
                    Route = $"wwwroot/Uploads/{ArchiveName}";
                    RelativeRoute = $"/Uploads/{ArchiveName}";
                    using (var stream = new FileStream(Route, FileMode.Create))
                    {
                        await imageToUpload.Archivo.CopyToAsync(stream);
                    }
                }
                postToCreate.Route = RelativeRoute;
                var PostCreated = await _repository.Add(postToCreate);

                if (PostCreated != null)
                {
                    foreach (Categorie categorie in postToCreate.Categories)
                    {
                        await _repository.AddRelation(PostCreated.PostId, categorie.CategorieId);
                    }
                    return PostCreated;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Ah ocurrido un error tratando de añadir el post: " + ex.Message);
            }
            
        }

        public async Task<bool> DeletePost(int id)
        {
            try
            {
                var postToDelete = await GetPost(id);
                if (postToDelete != null)
                {
                    var PostDeleted = await _repository.Delete(id);
                    if (PostDeleted == null)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex) 
            {
                throw new Exception("Ah ocurrido un error tratando de eliminar el post: " + ex.Message);
            }
            
        }

        public async Task<bool> EditPost(PostUpdateDto postUpdateDto)
        {
            try
            {
                var ExistPost = await _repository.GetById(postUpdateDto.postId);
                if (ExistPost == null)
                {
                    return false;
                }
                var postUpdated = await _repository.Update(postUpdateDto);
                if (postUpdated == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex) 
            {
                throw new Exception("Ah ocurrido un error tratando de editar el post: " + ex.Message);
            }
            
        }

    }
}
