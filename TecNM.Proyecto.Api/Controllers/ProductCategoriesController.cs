using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;


namespace TecNM.Proyecto.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductCategoryController : ControllerBase
{
    private readonly IProductCategoryService _productCategoryService;
    public ProductCategoryController(IProductCategoryService productCategoryService)
    {
        _productCategoryService = productCategoryService;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<ProductCategoryDto>>>> GetAll()
    {
        var response = new Response<List<ProductCategoryDto>>{
            Data = await _productCategoryService.GetAllAsync()
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Post([FromBody] ProductCategoryDto categoryDto){   
        var response = new Response<ProductCategoryDto>{
            Data = await _productCategoryService.SaveAsync(categoryDto)
        };
        return Created($"/api/[controller]/{response.Data.Id}",response);
    } 
    //route id:int para getbyid
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> GetById(int id){
        var response = new Response<ProductCategoryDto>();
        if(!await _productCategoryService.ProductCategoryExist(id)){
            response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }
        response.Data = await _productCategoryService.GetById(id);
        return Ok(response);
    }
    //Actualizar
    [HttpPut]
        public async Task<ActionResult<Response<ProductCategoryDto>>> Update([FromBody] ProductCategoryDto categoryDto){
        var response = new Response<ProductCategoryDto>();
        
        if(!await _productCategoryService.ProductCategoryExist(categoryDto.Id))
        {
           response.Errors.Add("Product Category Not Found");
            return NotFound(response);
        }       

        response.Data = await _productCategoryService.UpdateAsync(categoryDto);

        return Ok(response);
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategory>>> Delete(int id){
       var response = new Response<bool>();
        var result = await _productCategoryService.DeleteAsync(id);
        response.Data = result;
        
        return Ok(response);
    }


}