using app_cw7.Models;
using app_cw7.Repositories;

namespace app_cw7.Services;

public class ProductsService : IProductsService
{
    private IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public bool GetProduct(int id)
    {
        Product product = _productsRepository.getProduct(id);
        if (product == null)
            throw new Exception($"Product with given id: {id} doesn't exist");
        return true;
    }
}