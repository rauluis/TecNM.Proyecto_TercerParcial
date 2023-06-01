using System.ComponentModel.DataAnnotations;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;

public class ProductDto : DtoBase
{
    [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ ]+$", 
    ErrorMessage = "El campo Name SOLO debe contener caracteres alfabeticos.")]
    [StringLength(45, MinimumLength =1, ErrorMessage = "El campo Name debe tener minimo 1 caracter y maximo 45.")]
    public string Name { get; set; }
    [RegularExpression("^(?=[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ0-9])[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ0-9 ]+$",
     ErrorMessage = "El campo Descripcion SOLO debe contener caracteres alfabéticos, números y espacios (pero no al inicio).")]
    [StringLength(45, MinimumLength = 1, ErrorMessage = "El campo Descriocion debe tener minimi 1 caracter y maximo 45.")]
    public string Description { get; set; }
    
    [RegularExpression(@"^\d{1,4}([.,]\d{1,2})?$", 
    ErrorMessage = "El precio debe ser un número válido con un máximo de 4 dígitos antes del punto decimal y 2 dígitos después.")]
    public double Price { get; set; }
    [StringLength(500, ErrorMessage = "La URL de la imagen no puede tener más de 300 caracteres.")]
    public string Image { get; set; }
    [RegularExpression("^[0-9]{1,4}$", ErrorMessage = "El campo stock solo debe contener caracteres numéricos y 4 caracteres.")]
     public int Stock { get; set; }
     [RegularExpression("^[1-9][0-9]{0,44}$", 
     ErrorMessage = "El campo ID solo debe contener caracteres numéricos, tener una longitud máxima de 45 y no puede empezar por 0.")]
      public int IdCategory { get; set; }

    
    public ProductDto()
    {

    }
    public ProductDto(Product Product)
    {

        Id = Product.Id;
        Name = Product.Name;
        Description = Product.Description;
        Price = Product.Price;
        Image = Product.Image;
        Stock = Product.Stock;
        IdCategory = Product.IdCategory;

        
    }

}