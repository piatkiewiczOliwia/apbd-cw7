namespace app_cw7.Services;

public interface IWarehouses_ProductsService
{
    public int InsertProductEntry(int idWarehouse, int idProduct, int amount, DateTime createdAt);
}