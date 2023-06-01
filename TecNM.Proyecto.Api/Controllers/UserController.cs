using Microsoft.AspNetCore.Mvc;
using TecNM.Proyecto.Core.Entities;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.Services.interfaces;


namespace TecNM.Proyecto.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly IUserService _UserService;
    public UserController(IUserService UserService)
    {
        _UserService = UserService;
    }
    [HttpGet]
    public async Task<ActionResult<Response<List<UserDto>>>> GetAll()
    {
         var response = new Response<List<UserDto>>{
            Data = await _UserService.GetAllAsync()
        };
        return Ok(response);
    }
    [HttpPost]
    public async Task<ActionResult<Response<UserDto>>> Post([FromBody] UserDto UserDto){
        var response = new Response<UserDto>{
            Data = await _UserService.SaveAsync(UserDto)
        };
        return Created($"/api/[controller]/{response.Data.Id}",response);
    } 
    //route id:int para getbyid
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<UserDto>>> GetById(int id){
        var response = new Response<UserDto>();
        if(!await _UserService.UserExist(id)){
            response.Errors.Add("User Not Found");
            return NotFound(response);
        }
        response.Data = await _UserService.GetById(id);
        return Ok(response);
    }
    [HttpGet]
    [Route("{username}")]
    public async Task<ActionResult<Response<UserDto>>> GetByUserName(string username){
        var response = new Response<UserDto>();
    
        if (await _UserService.UserNameExist(username))
        {
            response.Data = await _UserService.GetByUserName(username);
            return Ok(response);
        }
        else
        {
            response.Errors.Add("User Not Found");
            return NotFound(response);
        }
    }
    
    //Actualizar
    [HttpPut]
    public async Task<ActionResult<Response<UserDto>>> Update([FromBody] UserDto UserDto){
        var response = new Response<UserDto>();
        if(!await _UserService.UserExist(UserDto.Id))
        {
           response.Errors.Add("User Not Found");
            return NotFound(response);
        }       
        response.Data = await _UserService.UpdateAsync(UserDto);
        return Ok(response);
    }
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<User>>> Delete(int id){   
        var response = new Response<bool>();
        var result = await _UserService.DeleteAsync(id);
        response.Data = result;
        
        
        
        return Ok(response);

    }


}