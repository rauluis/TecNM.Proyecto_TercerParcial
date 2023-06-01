using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.User;

public class ListModel : PageModel
{
    private readonly IUserService _service;
    public List<UserDto> User { get; set; }
    
    public ListModel(IUserService service)
    {
        User = new List<UserDto>();
        _service = service;
    }
    
    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        User = response.Data;
        return Page();
    }
}