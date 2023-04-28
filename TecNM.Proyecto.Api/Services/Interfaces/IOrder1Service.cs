using TecNM.Proyecto.Core.Dto;

namespace TecNM.Proyecto.Api.Services.interfaces;

public interface IOrder1Service
{

    //metodo para guardar orders
    Task<Order1Dto> SaveAsync(Order1Dto Order1);

    //Metodo para actualizar las orders de Productos
    Task<Order1Dto> UpdateAsync(Order1Dto Order1);
    //Metodo para retornar una Lista de orders
    Task<List<Order1Dto>> GetAllAsync();

    //Metodo para retornar el id de las orders que borrara
    Task<bool> Order1Exist(int id);

    //Metodo para obtener uan categoria por id
    Task<Order1Dto> GetById(int id);

    Task<bool> DeleteAsync(int id);
    
}