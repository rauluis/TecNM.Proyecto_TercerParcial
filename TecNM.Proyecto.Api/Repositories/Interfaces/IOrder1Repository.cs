using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IOrder1Repository
{

    Task<Order1> SaveAsync(Order1 Order1);


    Task<Order1> UpdateAsync(Order1 Order1);
    Task<List<Order1>> GetAllAsync();


    Task<bool> DeleteAsync(int id);

    Task<Order1> GetById(int id);

    }