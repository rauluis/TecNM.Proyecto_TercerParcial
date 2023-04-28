using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.DataAccess.Interfaces;
using TecNM.Proyecto.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
namespace TecNM.Proyecto.Api.Repositories;

public class ProductRepository:IProductRepository
{   

    private readonly IDbContext _dbContext;

    public ProductRepository(IDbContext context){
        _dbContext = context;
    }
    
    public async Task<Product> SaveAsync(Product  product)
    {
        product.Id = await _dbContext.Connection.InsertAsync( product);

        return product;
    }

    public async Task<Product> UpdateAsync(Product  product)
    {
        await _dbContext.Connection.UpdateAsync( product);
        return product;

    }

    public async Task<List<Product>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Product WHERE IsDeleted = 0";
        var categories = await _dbContext.Connection.QueryAsync<Product>(sql);
        return categories.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
       var product = await GetById(id);
       if (product == null){
         return false;
       }
       product.IsDeleted = true;

       return await _dbContext.Connection.UpdateAsync( product);
    }
    public async Task<Product> GetById(int id)
    {
        var product = await _dbContext.Connection.GetAsync<Product>(id);

        if(product == null){
            return null;
        }
        return product.IsDeleted == true ? null: product;
    }
}