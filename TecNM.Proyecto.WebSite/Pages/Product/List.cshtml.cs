using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.Product;

public class ListModel : PageModel
{
    private readonly IProductService _service;
    public List<ProductDto> Product { get; set; }
    
    public ListModel(IProductService service)
    {
        Product = new List<ProductDto>();
        _service = service;
    }
    
    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        Product = response.Data;
        return Page();
    }
}