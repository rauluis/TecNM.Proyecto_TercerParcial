using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.User;

public class Delete : PageModel
{
    
    [BindProperty] public UserDto User { get; set;}
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IUserService _service;

    public Delete(IUserService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        User = new UserDto();
        //Obtener informacion del servicio(API) 
        var response = await _service.GetById(id);
        User = response.Data;
        
        if (User == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(User.Id);
        return RedirectToPage("./List");
    }
}