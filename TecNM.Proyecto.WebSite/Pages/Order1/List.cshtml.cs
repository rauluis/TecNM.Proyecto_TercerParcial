using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.Order1;

public class ListModel : PageModel
{
    
    private readonly IOrder1Service _service;
    public List<Order1Dto> Order1 { get; set; }
    
    public ListModel(IOrder1Service service)
    {
        Order1 = new List<Order1Dto>();
        _service = service;
    }
    
    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        Order1 = response.Data;
        return Page();
    }
}