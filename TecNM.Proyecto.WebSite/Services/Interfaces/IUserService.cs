using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Services.Interfaces;

public interface IUserService
{
    Task<Response<List<UserDto>>> GetAllAsync();
    
    Task<Response<UserDto>> GetById(int id);
    
    Task<Response<UserDto>> SaveAsync(UserDto User);
    
    Task<Response<UserDto>> UpdateAsync(UserDto User);

    Task<Response<bool>> DeleteAsync(int id);
    
    Task<Response<UserDto>> GetByUserName(string username);

    Task<Response<UserDto>> LoginAsync(string username,string password);
}