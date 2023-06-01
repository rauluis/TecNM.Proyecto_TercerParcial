using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Proyecto.Core.Dto;
using TecNM.Proyecto.Core.Http;
using TecNM.Proyecto.WebSite.Services.Interfaces;

namespace TecNM.Proyecto.WebSite.Pages.ProductCategory;

public class Edit : PageModel
{
    [BindProperty] public ProductCategoryDto ProductCategory { get; set;}
    public List<string> Errors { get; set; } = new List<string>();
    private readonly IProductCategoryService _service;

    public Edit(IProductCategoryService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int? id)
    {
        ProductCategory = new ProductCategoryDto();
        if (id.HasValue)
        {
            //Obtener informacion del servicio(API)
            var response = await _service.GetById(id.Value);
            ProductCategory = response.Data;
        }

        if (ProductCategory == null)
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

        Response<ProductCategoryDto> response;

        if (ProductCategory.Id > 0)
        {
            //Actualizar 
            response = await _service.UpdateAsync(ProductCategory);
        }
        else
        {
            //Insertar
            response = await _service.SaveAsync(ProductCategory); 
        }

        Errors = response.Errors;

        if (Errors.Count > 0)
        {
            return Page();
        }

        ProductCategory = response.Data;
        return RedirectToPage("./List");
    }
}