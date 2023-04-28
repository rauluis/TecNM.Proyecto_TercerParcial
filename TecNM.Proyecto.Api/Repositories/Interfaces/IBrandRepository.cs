using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IBrandRepository
{
    //metodo para guardar categorias

    Task<Brand> SaveAsync(Brand brand);

    //Metodo para actualizar las categorias de Productos

    Task<Brand> UpdateAsync(Brand brand);
    //Metodo para retornar una Lista de categorias
    Task<List<Brand>> GetAllAsync();

    //Metodo para retornar el id de las categorias que borrara

    Task<bool> DeleteAsync(int id);

    //Metodo para obtener uan categoria por id
    Task<Brand> GetById(int id);

    }