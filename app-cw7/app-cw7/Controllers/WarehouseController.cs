using Microsoft.AspNetCore.Mvc;
using app_cw7.Models;
using app_cw7.Services;

namespace WebApplication3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseController : ControllerBase
{
    private IProductsService _productsService;
    private IWarehousesService _warehousesService;
    private IOrdersService _ordersService;

    public WarehouseController(IProductsService productsService, IWarehousesService warehousesService, IOrdersService ordersService)
    {
        _productsService = productsService;
        _warehousesService = warehousesService;
        _ordersService = ordersService;
    }

    [HttpPost]
    public IActionResult PostEntry(ProductEntry entry)
    {
        var productExists = _productsService.GetProduct(entry.IdProduct);
        if (!productExists)
            return NotFound($"Produkt o id: {entry.IdProduct} nie istnieje.");

        var warehouseExists = _warehousesService.GetWarehouse(entry.IdWarehouse);
        if (!warehouseExists)
            return NotFound($"Warehouse o id: {entry.IdWarehouse} nie istnieje.");

        if (entry.Amount <= 0)
            return BadRequest("Ilość powinna być większa od zera.");

        var idAndAmountInAnOrder = _ordersService.GetProductInOrderWithAmount(entry.IdProduct, entry.Amount, entry.CreatedAt);
        if (!idAndAmountInAnOrder)
            return BadRequest("Nie ma zamówienia na produkt o tym id na tą ilość");
        
        return Ok(entry);
    }
}

public class ProductEntry
{
    public int IdProduct { get; set; }
    public int IdWarehouse { get; set; }
    public int Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}