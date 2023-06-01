using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.OrderDetails;

public class Delete : PageModel
{
   
    [BindProperty] public OrderDetailsDto OrderDetails { get; set;}
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IOrderDetailsService _service;

    public Delete(IOrderDetailsService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        OrderDetails = new OrderDetailsDto();
        //Obtener informacion del servicio(API) 
        var response = await _service.GetById(id);
        OrderDetails = response.Data;
        
        if (OrderDetails == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(OrderDetails.Id);
        return RedirectToPage("./List");
    }
}