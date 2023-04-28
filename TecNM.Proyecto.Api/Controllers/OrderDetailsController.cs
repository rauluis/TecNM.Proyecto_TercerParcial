using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;


namespace TecNM.Proyecto.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderDetailsController : ControllerBase
{

    private readonly IOrderDetailsService _OrderDetailsService;
    public OrderDetailsController(IOrderDetailsService OrderDetailsService)
    {
        _OrderDetailsService = OrderDetailsService;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<OrderDetailsDto>>>> GetAll()
    {
        var response = new Response<List<OrderDetailsDto>>{
            Data = await _OrderDetailsService.GetAllAsync()
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<OrderDetailsDto>>> Post([FromBody] OrderDetailsDto OrderDetailsDto){
        var response = new Response<OrderDetailsDto>{
            Data = await _OrderDetailsService.SaveAsync(OrderDetailsDto)
        };
        return Created($"/api/[controller]/{response.Data.Id}",response);
    } 
    //route id:int para getbyid
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<OrderDetailsDto>>> GetById(int id){
        var response = new Response<OrderDetailsDto>();
        if(!await _OrderDetailsService.OrderDetailsExist(id)){
            response.Errors.Add("OrderDetails Not Found");
            return NotFound(response);
        }
        response.Data = await _OrderDetailsService.GetById(id);
        return Ok(response);
    }
    //Actualizar
    [HttpPut]
    public async Task<ActionResult<Response<OrderDetailsDto>>> Update([FromBody] OrderDetailsDto OrderDetailsDto){
        var response = new Response<OrderDetailsDto>();
        if(!await _OrderDetailsService.OrderDetailsExist(OrderDetailsDto.Id))
        {
           response.Errors.Add("OrderDetails Not Found");
            return NotFound(response);
        }       
        response.Data = await _OrderDetailsService.UpdateAsync(OrderDetailsDto);
        return Ok(response);
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<OrderDetails>>> Delete(int id){
  
        var response = new Response<bool>();
        var result = await _OrderDetailsService.DeleteAsync(id);
        response.Data = result;        
        return Ok(response);

    }


}