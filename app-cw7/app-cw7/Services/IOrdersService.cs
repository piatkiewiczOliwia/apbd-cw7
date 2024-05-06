namespace app_cw7.Services;

public interface IOrdersService
{
    public bool GetProductInOrderWithAmount(int id, int amount, DateTime createdAt);
}