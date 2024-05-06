using app_cw7.Models;

namespace app_cw7.Repositories;

public interface IProductsRepository
{
    public Product getProduct(int id); 
}