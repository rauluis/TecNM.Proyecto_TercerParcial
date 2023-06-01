using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.Catalog;

public class store : PageModel
{
    private readonly IProductService _service;
    public List<ProductDto> Product { get; set; }
    
    public store(IProductService service)
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