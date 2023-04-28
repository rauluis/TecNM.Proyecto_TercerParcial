using System.ComponentModel.DataAnnotations;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;

public class Order1Dto : DtoBase
{
    [RegularExpression("^[1-9][0-9]{0,44}$",
     ErrorMessage = "El campo ID solo debe contener caracteres numéricos, tener una longitud máxima de 45 y no puede empezar por 0.")]
    public int idUser { get; set; }
    
    [RegularExpression(@"^\d{1,10}([.,]\d{1,2})?$", 
    ErrorMessage = "El total debe ser un número válido con un máximo de 10 dígitos antes del punto decimal y 2 dígitos después.")]
    public double Ammount { get; set; }

    [Required(ErrorMessage = "El campo Available es obligatorio.")]
    public bool Available { get; set; }

    public Order1Dto()
    {

    }
    public Order1Dto(Order1 Order1)
    {

        Id = Order1.Id;
        idUser = Order1.idUser;
        Ammount = Order1.Ammount;
        Available = Order1.Available;

    }

}