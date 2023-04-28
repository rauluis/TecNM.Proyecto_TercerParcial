using TecNM.Proyecto.Core.Dto;

namespace TecNM.Proyecto.Api.Services.interfaces;

public interface IOrderDetailsService
{

    //metodo para guardar ordenes
    Task<OrderDetailsDto> SaveAsync(OrderDetailsDto OrderDetails);

    //Metodo para actualizar las ordenes de Productos
    Task<OrderDetailsDto> UpdateAsync(OrderDetailsDto OrderDetails);
    //Metodo para retornar una Lista de ordenes
    Task<List<OrderDetailsDto>> GetAllAsync();

    //Metodo para retornar el id de las ordenes que borrara
    Task<bool> OrderDetailsExist(int id);

    //Metodo para obtener uan categoria por id
    Task<OrderDetailsDto> GetById(int id);

    Task<bool> DeleteAsync(int id);

    
}