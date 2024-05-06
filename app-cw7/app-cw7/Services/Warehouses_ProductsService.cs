using app_cw7.Models;
using app_cw7.Repositories;

namespace app_cw7.Services;

public class Warehouses_ProductsService : IWarehouses_ProductsService
{
    private IProductsRepository _productsRepository;
    private IProducts_WarehousesRepository _productsesWarehousesRepository;
    private IOrdersRepository _ordersRepository;

    public Warehouses_ProductsService(IProductsRepository productsRepository, IProducts_WarehousesRepository productsesWarehousesRepository, IOrdersRepository ordersRepository)
    {
        _productsRepository = productsRepository;
        _productsesWarehousesRepository = productsesWarehousesRepository;
        _ordersRepository = ordersRepository;
    }

    public int InsertProductEntry(int idWarehouse, int idProduct, int amount, DateTime createdAt)
    {
        Product product = _productsRepository.getProduct(idProduct);
        var price = product.Price * amount;
        Order order = _ordersRepository.GetProductInOrderWithAmount(idProduct, amount);
        var insertedId = _productsesWarehousesRepository.InsertProductEntry(idWarehouse, idProduct, order.IdOrder, amount, createdAt, price);
        return insertedId;
    }
}