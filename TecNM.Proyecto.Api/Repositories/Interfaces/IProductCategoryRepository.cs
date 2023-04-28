using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IProductCategoryRepository
{

    Task<ProductCategory> SaveAsync(ProductCategory category);


    Task<ProductCategory> UpdateAsync(ProductCategory category);
    Task<List<ProductCategory>> GetAllAsync();


    Task<bool> DeleteAsync(int id);

    Task<ProductCategory> GetById(int id);

    }