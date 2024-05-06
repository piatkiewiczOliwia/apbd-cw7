using app_cw7.Models;
using Microsoft.Data.SqlClient;

namespace app_cw7.Repositories;

public class WarehousesRepository : IWarehousesRepository
{
    private readonly string _connectionString;

    public WarehousesRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public Warehouse GetWarehouse(int id)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();

        using SqlCommand cmd = new SqlCommand("SELECT IdWarehouse, Name, Address FROM Warehouse WHERE IdWarehouse = @WarehouseId", con);
        cmd.Parameters.AddWithValue("@WarehouseId", id);
        
        var reader = cmd.ExecuteReader();

        Warehouse warehouse;
        if (reader.Read())
        {
            warehouse = new Warehouse
            {
                WarehouseId = (int)reader["IdWarehouse"],
                Name = reader["Name"].ToString(),
                Address = reader["Address"].ToString()
            };
        }
        else
        {
            warehouse = null;
        }

        return warehouse;
    }

}