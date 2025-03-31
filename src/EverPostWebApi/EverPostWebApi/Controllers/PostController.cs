using EverPostWebApi.DTOs;
using EverPostWebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace EverPostWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService<Post> _postService;
        public PostController(IPostService<Post> postService)
        {
            _postService = postService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddPost([FromForm]UploadImage image, [FromForm] string postToCreateJson) 
        {
            var postToCreate = JsonSerializer.Deserialize<PostCreateDto>(postToCreateJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var postInserted = await _postService.AddPost(image, postToCreate);
            if (!postInserted)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false});
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            }
        
        }
    }
}
