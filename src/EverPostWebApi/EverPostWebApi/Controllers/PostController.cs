﻿using Azure;
using EverPostWebApi.Commons;
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
            var response = new BaseResponse<PostsPaginatedDTO>();
            try
            {
                var postsPaginatedDTO = await _postService.GetAllPosts(pageNumber, PageSize);
                if (postsPaginatedDTO == null)
                {
                    response.Success = false;
                    response.Message = "No se encontraron posts";
                    return Ok(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "Post recibidos satisfactoriamente";
                    response.Data = postsPaginatedDTO;
                    return Ok(response);
                }

            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.Message = "Ah ocurrido un error al tratar de consultar los posts";
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Post>> AddPost([FromForm]UploadImage image, [FromForm] string postToCreateJson) 
        {
            var response = new BaseResponse<Post>();
            try
            {
                var postToCreate = JsonSerializer.Deserialize<PostCreateDto>(postToCreateJson, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var postInserted = await _postService.AddPost(image, postToCreate);
                if (postInserted != null)
                {
                    response.Success = true;
                    response.Message = "Post agregado satisfactoriamente";
                    response.Data = postInserted;
                    return Ok(response);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Ah ocurrido un error al tratar de Añadir el post";
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ah ocurrido un error al tratar de Añadir el post";
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id) 
        {
            var response = new BaseResponse<string>();
            try
            {
                var result = await _postService.DeletePost(id);
                if (result)
                {
                    response.Success = true;
                    response.Message = "Post eliminado satisfactoriamente";
                    response.Data = "";
                    return Ok(response);
                }
                else 
                {
                    response.Success = false;
                    response.Message = "Ah ocurrido un error al tratar de eliminar el post";
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                }
                
            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.Message = "Ah ocurrido un error al tratar de eliminar el post";
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut]
        public async Task<IActionResult>UpdatePost(PostUpdateDto postUpdateDto)
        {
            var response = new BaseResponse<string>();
            try
            {
                var result = await _postService.EditPost(postUpdateDto);
                if (result)
                {
                    response.Success = true;
                    response.Message = "Post editado satisfactoriamente";
                    response.Data = "";
                    return Ok(response);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Ah ocurrido un error al tratar de editar el post";
                    return StatusCode(StatusCodes.Status500InternalServerError, response);
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Ah ocurrido un error al tratar de editar el post";
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
