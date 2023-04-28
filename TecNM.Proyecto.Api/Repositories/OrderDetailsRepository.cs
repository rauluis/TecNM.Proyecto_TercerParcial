using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.DataAccess.Interfaces;
using TecNM.Proyecto.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
namespace TecNM.Proyecto.Api.Repositories;

public class OrderDetailsRepository : IOrderDetailsRepository
{   
    private readonly IDbContext _dbContext;
    public OrderDetailsRepository(IDbContext context){
        _dbContext = context;
    }
   
    public async Task<OrderDetails> SaveAsync(OrderDetails OrderDetails)
    {
        //metodo propio para hacer incersiones asincronas 
        OrderDetails.Id = await _dbContext.Connection.InsertAsync(OrderDetails);
        return OrderDetails;
    }
    public async Task<OrderDetails> UpdateAsync(OrderDetails OrderDetails)
    {
        await _dbContext.Connection.UpdateAsync(OrderDetails);
        return OrderDetails;
    }

    public async Task<List<OrderDetails>> GetAllAsync()
    {
        const string sql = "SELECT * FROM OrderDetails WHERE IsDeleted = 0";
        var categories = await _dbContext.Connection.QueryAsync<OrderDetails>(sql);
        return categories.ToList();
    }
    public async Task<bool> DeleteAsync(int id)
    {
       var OrderDetails = await GetById(id);
       if (OrderDetails == null){
         return false;
       }
       OrderDetails.IsDeleted = true;
       return await _dbContext.Connection.UpdateAsync(OrderDetails);
    }
    public async Task<OrderDetails> GetById(int id)
    {
        var OrderDetails = await _dbContext.Connection.GetAsync<OrderDetails>(id);

        if(OrderDetails == null){
            return null;
        }
        return OrderDetails.IsDeleted == true ? null: OrderDetails;
    }
}