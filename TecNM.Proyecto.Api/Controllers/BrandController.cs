// using Microsoft.AspNetCore.Mvc;
// using TecNM.Proyecto.Core.Entities;
// using TecNM.Proyecto.Core.Http;
// using TecNM.Proyecto.Core.Dto;
// using TecNM.Proyecto.Api.Repositories.Interfaces;
// using TecNM.Proyecto.Api.Services.interfaces;


// namespace TecNM.Proyecto.Api.Controllers;


// [ApiController]
// [Route("api/[controller]")]
// public class BrandController : ControllerBase
// {

//     private readonly IBrandService _brandService;
//     public BrandController(IBrandService BrandService)
//     {
//         _brandService = BrandService;
//     }
//     [HttpGet]
//     public async Task<ActionResult<Response<List<BrandDto>>>> GetAll()
//     {

//          var response = new Response<List<BrandDto>>{

//             Data = await _brandService.GetAllAsync()
//         };
//         return Ok(response);
//     }

//     [HttpPost]
//     public async Task<ActionResult<Response<BrandDto>>> Post([FromBody] BrandDto brandDto){
//         var response = new Response<BrandDto>{

//             Data = await _brandService.SaveAsync(brandDto)
//         };
        
//         return Created($"/api/[controller]/{response.Data.Id}",response);


//     } 
//     //route id:int para getbyid
//     [HttpGet]
//     [Route("{id:int}")]
//     public async Task<ActionResult<Response<BrandDto>>> GetById(int id){

//         var response = new Response<BrandDto>();
        
//         if(!await _brandService.BrandExist(id)){
//             response.Errors.Add("Brand Not Found");
//             return NotFound(response);
//         }
//         response.Data = await _brandService.GetById(id);
//         return Ok(response);

//     }
//     //Actualizar
//     [HttpPut]
    
//     public async Task<ActionResult<Response<BrandDto>>> Update([FromBody] BrandDto brandDto){

//         var response = new Response<BrandDto>();
        
//         if(!await _brandService.BrandExist(brandDto.Id))
//         {
//            response.Errors.Add("Brand Not Found");
//             return NotFound(response);
//         }       

//         response.Data = await _brandService.UpdateAsync(brandDto);


//         return Ok(response);

//     }

//     [HttpDelete]
//     [Route("{id:int}")]
//     public async Task<ActionResult<Response<Brand>>> Delete(int id){

        
       
//         var response = new Response<bool>();
//         var result = await _brandService.DeleteAsync(id);
//         response.Data = result;
        
        
        
//         return Ok(response);

//     }


// }