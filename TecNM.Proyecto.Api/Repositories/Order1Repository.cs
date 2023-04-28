using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.DataAccess.Interfaces;
using TecNM.Proyecto.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
namespace TecNM.Proyecto.Api.Repositories;

public class Order1Repository : IOrder1Repository
{   
    private readonly IDbContext _dbContext;
    public Order1Repository(IDbContext context){
        _dbContext = context;
    }
    public async Task<Order1> SaveAsync(Order1 Order1)
    {
        //metodo propio para hacer incersiones asincronas 
        Order1.Id = await _dbContext.Connection.InsertAsync(Order1);
        return Order1;
    }
    public async Task<Order1> UpdateAsync(Order1 Order1)
    {
        await _dbContext.Connection.UpdateAsync(Order1);
        return Order1;
    }

    public async Task<List<Order1>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Order1 WHERE IsDeleted = 0";
        var categories = await _dbContext.Connection.QueryAsync<Order1>(sql);
        return categories.ToList();
    }
    public async Task<bool> DeleteAsync(int id)
    {
       var Order1 = await GetById(id);
       if (Order1 == null){
         return false;
       }
       Order1.IsDeleted = true;
       return await _dbContext.Connection.UpdateAsync(Order1);
    }
    public async Task<Order1> GetById(int id)
    {
        var Order1 = await _dbContext.Connection.GetAsync<Order1>(id);

        if(Order1 == null){
            return null;
        }
        return Order1.IsDeleted == true ? null: Order1;
    }
}