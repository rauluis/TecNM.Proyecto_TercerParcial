using TecNM.Proyecto.Core.Dto;

namespace TecNM.Proyecto.Api.Services.interfaces;

public interface IBrandService
{

    //metodo para guardar categorias
    Task<BrandDto> SaveAsync(BrandDto brand);

    //Metodo para actualizar las categorias de Productos
    Task<BrandDto> UpdateAsync(BrandDto brand);
    //Metodo para retornar una Lista de categorias
    Task<List<BrandDto>> GetAllAsync();

    //Metodo para retornar el id de las categorias que borrara
    Task<bool> BrandExist(int id);

    //Metodo para obtener uan categoria por id
    Task<BrandDto> GetById(int id);

    Task<bool> DeleteAsync(int id);

    
}