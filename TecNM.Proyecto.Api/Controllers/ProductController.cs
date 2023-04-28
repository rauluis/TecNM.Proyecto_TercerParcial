using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.Api.Services.interfaces;

namespace TecNM.Proyecto.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _ProductService;

    public ProductController(IProductService ProductService)
    {
        _ProductService = ProductService;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<ProductDto>>>> GetAll()
    {
        var response = new Response<List<ProductDto>>{

            Data = await _ProductService.GetAllAsync()
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<ProductDto>>> Post([FromBody] ProductDto categoryDto){
        
        var response = new Response<ProductDto>{

            Data = await _ProductService.SaveAsync(categoryDto)
        };
        
        return Created($"/api/[controller]/{response.Data.Id}",response);

    } 
    //route id:int para getbyid
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductDto>>> GetById(int id){

        var response = new Response<ProductDto>();
        
        if(!await _ProductService.ProductExist(id)){
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }
        response.Data = await _ProductService.GetById(id);
        return Ok(response);

    }
    //Actualizar
    [HttpPut]
        public async Task<ActionResult<Response<ProductDto>>> Update([FromBody] ProductDto categoryDto){
        var response = new Response<ProductDto>();
        
        if(!await _ProductService.ProductExist(categoryDto.Id))
        {
           response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }       

        response.Data = await _ProductService.UpdateAsync(categoryDto);

        return Ok(response);
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Product>>> Delete(int id){

       var response = new Response<bool>();
        var result = await _ProductService.DeleteAsync(id);
        response.Data = result;      
        return Ok(response);
    }


}