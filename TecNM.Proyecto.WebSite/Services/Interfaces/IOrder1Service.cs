using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Services.Interfaces;

public interface IOrder1Service
{
    Task<Response<List<Order1Dto>>> GetAllAsync();
    
    Task<Response<Order1Dto>> GetById(int id);
    
    Task<Response<Order1Dto>> SaveAsync(Order1Dto Order1);
    
    Task<Response<Order1Dto>> UpdateAsync(Order1Dto Order1);

    Task<Response<bool>> DeleteAsync(int id);
}