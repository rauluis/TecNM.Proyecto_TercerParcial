using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.User;

public class Edit : PageModel
{
    [BindProperty] public UserDto User { get; set;}
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IUserService _service;

    public Edit(IUserService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        User = new UserDto();
        if (id.HasValue)
        {
            //Obtener informacion del servicio(API)
            var response = await _service.GetById(id.Value);
            User = response.Data;
        }

        if (User == null)
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

        Response<UserDto> response;

        if (User.Id > 0)
        {
            //Actualizar 
            response = await _service.UpdateAsync(User);
        }
        else
        {
            //Insertar
            response = await _service.SaveAsync(User); 
        }

        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        User = response.Data;
        return RedirectToPage("./List");
    }
}