using System.ComponentModel.DataAnnotations;

namespace app_cw7.Models;

public class Product_Warehouse
{
    [Required] public int IdProductWarehouse { get; set; }
    [Required] public int IdWarehouse { get; set; }
    [Required] public int IdProduct { get; set; }
    [Required] public int IdOrder { get; set; }
    [Required] public int Amount { get; set; }
    [Required] [MaxLength(25)] public string Price { get; set; }
    [Required] [DataType(DataType.DateTime)] public DateTime CreatedAt { get; set; } 
}