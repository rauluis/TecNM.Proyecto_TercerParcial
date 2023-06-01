using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;

namespace TecNM.Proyecto.WebSite.Services.Interfaces;

public interface IProductCategoryService
{
    Task<Response<List<ProductCategoryDto>>> GetAllAsync();
    
    Task<Response<ProductCategoryDto>> GetById(int id);
    
    Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto ProductCategory);
    
    Task<Response<ProductCategoryDto>> UpdateAsync(ProductCategoryDto ProductCategory);

    Task<Response<bool>> DeleteAsync(int id);
}