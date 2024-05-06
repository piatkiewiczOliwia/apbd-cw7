using app_cw7.Models;

namespace app_cw7.Repositories;

public interface IOrdersRepository
{
    Order GetProductInOrderWithAmount(int id, int amount);
    void SetFulfilledAt(int id);
    
}