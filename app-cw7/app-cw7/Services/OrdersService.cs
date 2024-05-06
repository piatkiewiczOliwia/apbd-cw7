using app_cw7.Models;
using app_cw7.Repositories;

namespace app_cw7.Services;

public class OrdersService : IOrdersService
{
    private IOrdersRepository _ordersRepository;
    private IProducts_WarehousesRepository _productsesWarehousesRepository;

    public OrdersService(IOrdersRepository ordersRepository, IProducts_WarehousesRepository productsesWarehousesRepository)
    {
        _ordersRepository = ordersRepository;
        _productsesWarehousesRepository = productsesWarehousesRepository;
    }

    public bool GetProductInOrderWithAmount(int id, int amount, DateTime createdAt)
    {
        Order order = _ordersRepository.GetProductInOrderWithAmount(id, amount);
        if (order == null)
            throw new Exception("There is no order with this product id and amount!");
        if (!(order.CreatedAt > createdAt))
            throw new Exception("Data utworzenia pozniejsza niz w żądaniu");
        if (order.FulfilledAt != null)
            throw new Exception("Zamówienie zostało już zrealizowane");
        if (_productsesWarehousesRepository.CheckOrderId(order.IdOrder))
            throw new Exception("Zamówienie jest już w tabeli!!!");
        return true;
    }
}