using System.ComponentModel.DataAnnotations;
using TecNM.Proyecto.Core.Entities;
namespace TecNM.Proyecto.Core.Dto;

public class OrderDetailsDto : DtoBase
{
    [RegularExpression("^[1-9][0-9]{0,44}$", 
    ErrorMessage = "El campo ID solo debe contener caracteres numéricos, tener una longitud máxima de 45 y no puede empezar por 0.")]
    public int idProduct { get; set; }
    
    [RegularExpression("^[1-9][0-9]{0,44}$", 
    ErrorMessage = "El campo ID solo debe contener caracteres numéricos, tener una longitud máxima de 45 y no puede empezar por 0.")]
    public int idOrder { get; set; }

    [RegularExpression("^[0-9]{0,44}$",
     ErrorMessage = "El campo ID solo debe contener caracteres numéricos, tener una longitud máxima de 45 y no puede empezar por 0.")]
    public int Quantity { get; set; }

    public OrderDetailsDto()
    {

    }
    public OrderDetailsDto(OrderDetails OrderDetails)
    {

        Id = OrderDetails.Id;
        idOrder = OrderDetails.idOrder;
           idProduct = OrderDetails.idProduct;
        Quantity = OrderDetails.Quantity;
    }
}