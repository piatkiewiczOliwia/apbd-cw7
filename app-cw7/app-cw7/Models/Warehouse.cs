using System.ComponentModel.DataAnnotations;

namespace app_cw7.Models;

public class Warehouse
{
    [Required] public int WarehouseId { get; set; }
    [Required] [MaxLength(200)] public string Name { get; set; }
    [Required] [MaxLength(200)] public string Address { get; set; } 
}