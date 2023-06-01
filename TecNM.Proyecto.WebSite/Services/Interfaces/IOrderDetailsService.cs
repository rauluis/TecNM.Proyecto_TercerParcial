using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Services.Interfaces;

public interface IOrderDetailsService
{
    Task<Response<List<OrderDetailsDto>>> GetAllAsync();
    
    Task<Response<OrderDetailsDto>> GetById(int id);
    
    Task<Response<OrderDetailsDto>> SaveAsync(OrderDetailsDto OrderDetails);
    
    Task<Response<OrderDetailsDto>> UpdateAsync(OrderDetailsDto OrderDetails);

    Task<Response<bool>> DeleteAsync(int id);
}