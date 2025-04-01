using EverPostWebApi.Commons;
using EverPostWebApi.DTOs;
using EverPostWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EverPostWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametersController : ControllerBase
    {
        private readonly ICategorieService<Categorie> _categorieService;

        public ParametersController(ICategorieService<Categorie> categorieService)
        {
            _categorieService = categorieService;
        }
        
        [HttpGet("Categorie")]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategories() 
        {
            var response = new BaseResponse< IEnumerable < Categorie >> ();
            try
            {
                var categories = await _categorieService.GetCategories();
                if (categories == null)
                {
                    response.Success = false;
                    response.Message = "No se encontraron categorias";
                    return Ok(response);
                }
                else
                {
                    response.Success = true;
                    response.Message = "Categorias recibidass satisfactoriamente";
                    response.Data = categories;
                    return Ok(response);
                }
            }
            catch (Exception ex) 
            {
                response.Success = false;
                response.Message = "Ah ocurrido un error al tratar de consultar las Categorias";
                response.Errors.Add(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
