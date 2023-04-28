using System.ComponentModel.DataAnnotations;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;

public class BrandDto : DtoBase{


    [RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+$", ErrorMessage = "El campo Name SOLO debe contener caracteres alfabeticos.")]
    [StringLength(45, MinimumLength =1, ErrorMessage = "El campo Name debe tener minimo 1 caracter y maximo 45.")]    
    public string? Name { get; set; }

    [RegularExpression("^(?=[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ0-9])[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ0-9 ]+$", ErrorMessage = "El campo Descripcion SOLO debe contener caracteres alfabéticos, números y espacios (pero no al inicio).")]
    [StringLength(45, MinimumLength = 1, ErrorMessage = "El campo Descriocion debe tener minimi 1 caracter y maximo 45.")]
    public string? Description { get; set; }

public BrandDto(){

}
public BrandDto(Brand brand){
    
    Id = brand.Id;
    Name = brand.Name;
    Description = brand.Description;
    
} 

}