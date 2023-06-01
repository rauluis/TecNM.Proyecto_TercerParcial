using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.Product;

public class Edit : PageModel
{
    [BindProperty] public ProductDto Product { get; set;}
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IProductService _service;

    public Edit(IProductService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        Product = new ProductDto();
        if (id.HasValue)
        {
            //Obtener informacion del servicio(API)
            var response = await _service.GetById(id.Value);
            Product = response.Data;
        }

        if (Product == null)
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

        Response<ProductDto> response;

        if (Product.Id > 0)
        {
            //Actualizar 
            response = await _service.UpdateAsync(Product);
        }
        else
        {
            //Insertar
            response = await _service.SaveAsync(Product); 
        }

        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        Product = response.Data;
        return RedirectToPage("./List");
    }
}