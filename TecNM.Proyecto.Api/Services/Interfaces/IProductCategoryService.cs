using TecNM.Proyecto.Core.Dto;

namespace TecNM.Proyecto.Api.Services.interfaces;

public interface IProductCategoryService
{

    //metodo para guardar categorias
    Task<ProductCategoryDto> SaveAsync(ProductCategoryDto category);

    //Metodo para actualizar las categorias de Productos
    Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto category);
    //Metodo para retornar una Lista de categorias
    Task<List<ProductCategoryDto>> GetAllAsync();

    //Metodo para retornar el id de las categorias que borrara
    Task<bool> ProductCategoryExist(int id);

    //Metodo para obtener uan categoria por id
    Task<ProductCategoryDto> GetById(int id);

    Task<bool> DeleteAsync(int id);

    
}