using TecNM.Proyecto.Core.Entities;

namespace TecNM.Proyecto.Api.Repositories.Interfaces;

public interface IOrderDetailsRepository
{

    Task<OrderDetails> SaveAsync(OrderDetails OrderDetails);


    Task<OrderDetails> UpdateAsync(OrderDetails OrderDetails);
    Task<List<OrderDetails>> GetAllAsync();


    Task<bool> DeleteAsync(int id);

    Task<OrderDetails> GetById(int id);

    }