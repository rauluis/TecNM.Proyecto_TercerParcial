using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.OrderDetails;

public class Edit : PageModel
{
    [BindProperty] public OrderDetailsDto OrderDetails { get; set;}
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IOrderDetailsService _service;

    public Edit(IOrderDetailsService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        OrderDetails = new OrderDetailsDto();
        if (id.HasValue)
        {
            //Obtener informacion del servicio(API)
            var response = await _service.GetById(id.Value);
            OrderDetails = response.Data;
        }

        if (OrderDetails == null)
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

        Response<OrderDetailsDto> response;

        if (OrderDetails.Id > 0)
        {
            //Actualizar 
            response = await _service.UpdateAsync(OrderDetails);
        }
        else
        {
            //Insertar
            response = await _service.SaveAsync(OrderDetails); 
        }

        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        OrderDetails = response.Data;
        return RedirectToPage("./List");
    }
}