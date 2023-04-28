using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;


namespace TecNM.Proyecto.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class Order1Controller : ControllerBase
{

    private readonly IOrder1Service _Order1Service;
    public Order1Controller(IOrder1Service Order1Service)
    {
        _Order1Service = Order1Service;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<Order1Dto>>>> GetAll()
    {
         var response = new Response<List<Order1Dto>>{
            Data = await _Order1Service.GetAllAsync()
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<Order1Dto>>> Post([FromBody] Order1Dto Order1Dto){
        var response = new Response<Order1Dto>{
            Data = await _Order1Service.SaveAsync(Order1Dto)
        };
        return Created($"/api/[controller]/{response.Data.Id}",response);
    } 
    //route id:int para getbyid
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Order1Dto>>> GetById(int id){
        var response = new Response<Order1Dto>();
        if(!await _Order1Service.Order1Exist(id)){
            response.Errors.Add("Order1 Not Found");
            return NotFound(response);
        }
        response.Data = await _Order1Service.GetById(id);
        return Ok(response);
    }
    //Actualizar
    [HttpPut]
    public async Task<ActionResult<Response<Order1Dto>>> Update([FromBody] Order1Dto Order1Dto){
        var response = new Response<Order1Dto>();
        if(!await _Order1Service.Order1Exist(Order1Dto.Id))
        {
           response.Errors.Add("Order1 Not Found");
            return NotFound(response);
        }       
        response.Data = await _Order1Service.UpdateAsync(Order1Dto);
        return Ok(response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Order1>>> Delete(int id){  
        var response = new Response<bool>();
        var result = await _Order1Service.DeleteAsync(id);
        response.Data = result;
        return Ok(response);

    }


}