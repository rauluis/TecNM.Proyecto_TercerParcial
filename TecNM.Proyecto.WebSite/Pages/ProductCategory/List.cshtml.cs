using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.ProductCategory;

public class ListModel : PageModel
{
    private readonly IProductCategoryService _service;
    public List<ProductCategoryDto> ProductCategory { get; set; }
    
    public ListModel(IProductCategoryService service)
    {
        ProductCategory = new List<ProductCategoryDto>();
        _service = service;
    }
    
    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        ProductCategory = response.Data;
        return Page();
    }
}