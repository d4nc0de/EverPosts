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
        private IPostService<Post,PostsPaginatedDTO> _postService;
        public PostController(IPostService<Post, PostsPaginatedDTO> postService)
        {
            _postService = postService;
        }
        [HttpGet]
        public async Task<ActionResult<PostsPaginatedDTO>> GetPosts([FromQuery] int  pageNumber, [FromQuery] int PageSize) 
        {
            var postsPaginatedDTO = _postService.GetAllPosts(pageNumber, PageSize);
            if (postsPaginatedDTO == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, postsPaginatedDTO });
            }
        }

        [HttpPost]
        public async Task<ActionResult<Post>> AddPost([FromForm]UploadImage image, [FromForm] string postToCreateJson) 
        {
            var postToCreate = JsonSerializer.Deserialize<PostCreateDto>(postToCreateJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var postInserted = await _postService.AddPost(image, postToCreate);
            if (postInserted == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, postInserted });
            }
        
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id) 
        {
            var result = await _postService.DeletePost(id);
            if (!result) 
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            }
        }

        [HttpPut]
        public async Task<IActionResult>UpdatePost(PostUpdateDto postUpdateDto)
        {
            var result = await _postService.EditPost(postUpdateDto);
            if (!result)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true });
            }
        }
    }
}
