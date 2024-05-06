namespace app_cw7.Repositories;

public interface IProducts_WarehousesRepository
{
    public bool CheckOrderId(int idOrder);
    public int InsertProductEntry(int idWarehouse, int idProduct, int idOrder, int amount, DateTime createdAt, decimal price);
}