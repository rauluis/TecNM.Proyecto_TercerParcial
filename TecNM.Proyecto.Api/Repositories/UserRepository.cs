using TecNM.Proyecto.Api.Repositories.Interfaces;
using TecNM.Proyecto.Api.DataAccess.Interfaces;
using TecNM.Proyecto.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
namespace TecNM.Proyecto.Api.Repositories;

public class UserRepository : IUserRepository
{   
    private readonly IDbContext _dbContext;
    public UserRepository(IDbContext context){
        _dbContext = context;
    }
    
    public async Task<User> SaveAsync(User User)
    {
        //metodo propio para hacer incersiones asincronas 
        User.Id = await _dbContext.Connection.InsertAsync(User);
        return User;
    }
    public async Task<User> UpdateAsync(User User)
    {
        await _dbContext.Connection.UpdateAsync(User);
        return User;

    }

    public async Task<List<User>> GetAllAsync()
    {
        const string sql = "SELECT * FROM User WHERE IsDeleted = 0";

        var categories = await _dbContext.Connection.QueryAsync<User>(sql);
    
        return categories.ToList();
    }
    public async Task<bool> DeleteAsync(int id)
    {
       var User = await GetById(id);
       if (User == null){
         return false;
       }
       User.IsDeleted = true;
       return await _dbContext.Connection.UpdateAsync(User);

    }
    public async Task<User> GetById(int id)
    {
        var User = await _dbContext.Connection.GetAsync<User>(id);

        if(User == null){
            return null;
        }
        return User.IsDeleted == true ? null: User;
    }

    public async Task<User> GetByUserName(string username)
    {
        const string sql = "SELECT * FROM User WHERE Username = @Username";

        var user = await _dbContext.Connection.QueryFirstOrDefaultAsync<User>(sql, new { Username = username });

        return user;
    }
}