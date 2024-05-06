using System.ComponentModel.DataAnnotations;

namespace app_cw7.Models;

public class Product
{
    [Required] public int ProductId { get; set; }
    [Required]  public string Name { get; set; }
    [Required]  public string Description { get; set; }
    [Required]  public decimal Price { get; set; } 
}