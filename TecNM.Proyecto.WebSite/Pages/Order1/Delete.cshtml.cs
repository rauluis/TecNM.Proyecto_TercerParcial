using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.Order1;

public class Delete : PageModel
{
    
    [BindProperty] public Order1Dto Order1 { get; set;}
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IOrder1Service _service;

    public Delete(IOrder1Service service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        Order1 = new Order1Dto();
        //Obtener informacion del servicio(API) 
        var response = await _service.GetById(id);
        Order1 = response.Data;
        
        if (Order1 == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(Order1.Id);
        return RedirectToPage("./List");
    }
}