using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IProductRepository
{

    Task<Product> SaveAsync(Product Product);


    Task<Product> UpdateAsync(Product Product);
    Task<List<Product>> GetAllAsync();


    Task<bool> DeleteAsync(int id);

    Task<Product> GetById(int id);

    }