using EverPostWebApi.Commons;
using EverPostWebApi.DTOs;
using EverPostWebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EverPostWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentsService<Comment, DataPaginatedDTO<Comment>, CommentCreateDto> _commentService;
        public CommentsController(ICommentsService<Comment, DataPaginatedDTO<Comment>, CommentCreateDto> postService)
        {
            _commentService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<DataPaginatedDTO<Comment>>> GetPosts(PaginatorDto paginatorDto)
        {
            var response = new BaseResponse<DataPaginatedDTO<Comment>>();
            try
            {
                var postsPaginatedDTO = await _commentService.GetCommentsPaginated(paginatorDto);
                if (postsPaginatedDTO == null)
                {
                    response.Success = false;
                    response.Message = "No se encontraron Comentarios";
                    return Ok(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "Comentarios recibidos satisfactoriamente";
                    response.Data = postsPaginatedDTO;
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ah ocurrido un error al tratar de consultar los Comentarios";
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment(CommentCreateDto commentToCreate) 
        {
            var response = new BaseResponse<Comment>();
            try
            {
                var commentInserted = await _commentService.AddComment(commentToCreate);
                if (commentInserted == null)
                {
                    response.Success = false;
                    response.Message = "No se encontraron Comentarios";
                    return Ok(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "Comentarios recibidos satisfactoriamente";
                    response.Data = commentInserted;
                    return Ok(response);
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ah ocurrido un error al tratar de consultar los Comentarios";
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }

        }

    }
}
