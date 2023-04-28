using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User> SaveAsync(User user);
    
    Task<User> UpdateAsync(User user);
    
    Task<List<User>> GetAllAsync();
    
    Task<bool> DeleteAsync(int id);
    
    Task<User> GetById(int id); 
}
