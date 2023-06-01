using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger,IUserService userService)
    {
        _logger = logger;
        _service = userService;
    }
    [BindProperty] public string Password { get; set; }
    [BindProperty] public string Username { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IUserService _service;

    public async Task<IActionResult> OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            // Obtener los errores de validación del modelo
            var errorMessages = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);
            // Mostrar los errores en la salida de la consola
            foreach (var errorMessage in errorMessages)
            {
                Console.WriteLine(errorMessage);
            }
            return Page();
        }
        var response = await _service.LoginAsync(Username, Password);
        if (response.Success)
        {
            TempData["SuccessMessage"] = "Inicio de sesión exitoso.";
            // Inicio de sesión exitoso, puedes almacenar el usuario en la sesión o realizar otras acciones necesarias
            var loggedInUser = response.Data;
            return RedirectToPage("./User/UserInfo", new { id = loggedInUser.Id });
        }
        else
        {
            // Mostrar el mensaje de error en caso de que el usuario o la contraseña sean incorrectos
            Errors.Add(response.ErrorMessage);
            TempData["ErrorMessage"] = "Error al iniciar sesión. Verifica el usuario y la contraseña.";
            return Page();
        }
    }
}