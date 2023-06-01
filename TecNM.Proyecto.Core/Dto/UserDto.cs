using System.ComponentModel.DataAnnotations;

using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;

public class UserDto : DtoBase{

[RegularExpression("^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ]+$", ErrorMessage = "El campo 'Name' SOLO debe contener caracteres alfabeticos.")]
[StringLength(45, MinimumLength =1, ErrorMessage = "El campo 'Name' debe tener minimo 1 caracter y maximo 45.")]
public string? Name { get; set; }

[RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "El campo 'UserName' SOLO debe contener caracteres alfanumericos, sin espacios, ni acentos.")]
[StringLength(20, MinimumLength =1, ErrorMessage = "El campo 'UserName' debe tener minimo 1 caracter y maximo 20")]
public string Username { get; set; }

[StringLength(45, MinimumLength = 8, ErrorMessage = "La longitud de la contraseña debe estar entre 8 y 45 caracteres")]
[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,45}$",
 ErrorMessage = "La contraseña debe contener al menos una letra mayúscula, una letra minúscula, un número y un carácter especial")]
public string Password { get; set; }

[RegularExpression(@"^[0-9]*$", ErrorMessage = "El campo 'Phone' solo debe contener números")]
[StringLength(10, MinimumLength = 10, ErrorMessage = "El número de teléfono debe tener 10 dígitos")]
public string? Phone { get; set; }

[RegularExpression("^(?=[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ0-9])[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ0-9 #,.]+$", ErrorMessage = 
"El campo 'Address' SOLO debe contener caracteres alfabéticos, números y espacios (pero no al inicio).")]
[StringLength(300, MinimumLength = 1, ErrorMessage = "El campo 'Address' debe tener minimi 1 caracter y maximo 300.")]
public string? Address { get; set; }

public UserDto(){
}

public UserDto(User user){
    Id = user.Id;
    Name = user.Name;
    Username = user.Username;
    Phone = user.Phone;
    Password = user.Password;
    Address = user.Address;


} 

}