using TecNM.Proyecto.Core.Dto;

namespace TecNM.Proyecto.Api.Services.interfaces;

public interface IUserService
{
    //metodo para guardar usuarios
    Task<UserDto> SaveAsync(UserDto user);

    //Metodo para actualizar las usuarios 
    Task<UserDto> UpdateAsync(UserDto user);
    //Metodo para retornar una Lista de usuarios
    Task<List<UserDto>> GetAllAsync();

    //Metodo para retornar el id de las usuarios que borrara
    Task<bool> UserExist(int id);

    //Metodo para obtener uan usuario por id
    Task<UserDto> GetById(int id);

    Task<bool> DeleteAsync(int id);

    
}