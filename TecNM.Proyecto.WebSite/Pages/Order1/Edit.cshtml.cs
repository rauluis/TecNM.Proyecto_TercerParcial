using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.Order1;

public class Edit : PageModel
{
    [BindProperty] public Order1Dto Order1 { get; set;}
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IOrder1Service _service;

    public Edit(IOrder1Service service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        Order1 = new Order1Dto();
        if (id.HasValue)
        {
            //Obtener informacion del servicio(API)
            var response = await _service.GetById(id.Value);
            Order1 = response.Data;
        }

        if (Order1 == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<Order1Dto> response;

        if (Order1.Id > 0)
        {
            //Actualizar 
            response = await _service.UpdateAsync(Order1);
        }
        else
        {
            //Insertar
            response = await _service.SaveAsync(Order1); 
        }

        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        Order1 = response.Data;
        return RedirectToPage("./List");
    }
}