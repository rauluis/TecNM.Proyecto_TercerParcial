using System.ComponentModel.DataAnnotations;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;

public class ProductCategoryDto : DtoBase{


[RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+$", ErrorMessage = "El campo Name SOLO debe contener caracteres alfabeticos.")]
[StringLength(45, MinimumLength =1, ErrorMessage = "El campo Name debe tener minimo 1 caracter y maximo 45.")]
public string? Name { get; set; }


public ProductCategoryDto(){

}
public ProductCategoryDto(ProductCategory category){

    Name = category.Name;
    Id = category.Id;
    
} 

}