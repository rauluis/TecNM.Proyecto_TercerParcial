using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.DataAccess.Interfaces;
using TecNM.Proyecto.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
namespace TecNM.Proyecto.Api.Repositories;

public class BrandRepository : IBrandRepository
{   

    private readonly IDbContext _dbContext;

    public BrandRepository(IDbContext context){
        _dbContext = context;
    }
    
    public async Task<Brand> SaveAsync(Brand brand)
    {
        //metodo propio para hacer incersiones asincronas 
        brand.Id = await _dbContext.Connection.InsertAsync(brand);

        return brand;
    }

    public async Task<Brand> UpdateAsync(Brand brand)
    {
        await _dbContext.Connection.UpdateAsync(brand);
        return brand;

    }

    public async Task<List<Brand>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Brand WHERE IsDeleted = 0";

        var categories = await _dbContext.Connection.QueryAsync<Brand>(sql);
    
        return categories.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
       var Brand = await GetById(id);
       if (Brand == null){
         return false;
       }
       Brand.IsDeleted = true;

       return await _dbContext.Connection.UpdateAsync(Brand);

    }

    public async Task<Brand> GetById(int id)
    {
        var Brand = await _dbContext.Connection.GetAsync<Brand>(id);

        if(Brand == null){
            return null;
        }
        return Brand.IsDeleted == true ? null: Brand;
    }
}