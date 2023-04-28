namespace  TecNM.Proyecto.Core.Entities;

public class OrderDetails: EntityBase
{
    public int idOrder { get; set; }
    public int idProduct { get; set; }
    public int Quantity { get; set; }
}