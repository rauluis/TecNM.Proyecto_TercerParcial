using TecNM.Proyecto.Core.Dto;

namespace TecNM.Proyecto.Api.Services.interfaces;

public interface IProductService
{

    //metodo para guardar productos
    Task<ProductDto> SaveAsync(ProductDto Product);

    //Metodo para actualizar las productos
    Task<ProductDto> UpdateAsync(ProductDto Product);
    //Metodo para retornar una Lista de productos
    Task<List<ProductDto>> GetAllAsync();

    //Metodo para retornar el id de las productos que borrara
    Task<bool> ProductExist(int id);

    //Metodo para obtener uan categoria por id
    Task<ProductDto> GetById(int id);

    Task<bool> DeleteAsync(int id);

    
}