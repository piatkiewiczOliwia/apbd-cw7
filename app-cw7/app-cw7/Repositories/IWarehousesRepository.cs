using app_cw7.Models;

namespace app_cw7.Repositories;

public interface IWarehousesRepository
{
    Warehouse GetWarehouse(int id);
}