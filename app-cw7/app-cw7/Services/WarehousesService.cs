using app_cw7.Models;
using app_cw7.Repositories;

namespace app_cw7.Services;

public class WarehousesService : IWarehousesService
{
    private IWarehousesRepository _warehousesesRepository;

    public WarehousesService(IWarehousesRepository warehousesesRepository)
    {
        _warehousesesRepository = warehousesesRepository;
    }


    public bool GetWarehouse(int id)
    {
        Warehouse warehouse = _warehousesesRepository.GetWarehouse(id);
        if (warehouse == null)
            throw new Exception("Warehouse doesn't exist.");
        return true;
    }
}