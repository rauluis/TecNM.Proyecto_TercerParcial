using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Services.Interfaces;

public interface IProductService
{
    Task<Response<List<ProductDto>>> GetAllAsync();
    
    Task<Response<ProductDto>> GetById(int id);
    
    Task<Response<ProductDto>> SaveAsync(ProductDto Product);
    
    Task<Response<ProductDto>> UpdateAsync(ProductDto Product);
    Task<Response<bool>> DeleteAsync(int id);
}