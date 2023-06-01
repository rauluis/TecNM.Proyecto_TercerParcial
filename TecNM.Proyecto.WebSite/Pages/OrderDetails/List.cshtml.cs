using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.OrderDetails;

public class ListModel : PageModel
{
    private readonly IOrderDetailsService _service;
    public List<OrderDetailsDto> OrderDetails { get; set; }
    
    public ListModel(IOrderDetailsService service)
    {
        OrderDetails = new List<OrderDetailsDto>();
        _service = service;
    }
    
    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        OrderDetails = response.Data;
        return Page();
    }
}