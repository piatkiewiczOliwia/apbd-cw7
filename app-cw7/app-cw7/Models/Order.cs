using System.ComponentModel.DataAnnotations;

namespace app_cw7.Models;

public class Order
{
    [Required] public int IdOrder { get; set; }
    [Required] public int IdProduct { get; set; }
    [Required] public int Amount { get; set; }
    [Required] [DataType(DataType.DateTime)] public DateTime CreatedAt { get; set; }
    [DataType(DataType.DateTime)] public DateTime? FulfilledAt { get; set; } 
}