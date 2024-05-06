using Microsoft.Data.SqlClient;

namespace app_cw7.Repositories;

public class Products_WarehousesRepository : IProducts_WarehousesRepository
{
    private readonly string _connectionString;

    public Products_WarehousesRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public bool CheckOrderId(int idOrder)
    {
        using var con = new SqlConnection(_connectionString); 
        con.Open();

        using SqlCommand cmd = new SqlCommand("SELECT IdProductWarehouse FROM Product_Warehouse WHERE IdOrder = @IdOrder", con);
        cmd.Parameters.AddWithValue("@IdOrder", idOrder);
         
        var reader = cmd.ExecuteReader();
         
        if (reader.Read())
        {
            return true;
        }

        return false;
    }

    public int InsertProductEntry(int idWarehouse, int idProduct, int idOrder, int amount, DateTime createdAt, decimal price)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();
        
        using var cmd = new SqlCommand("INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt) OUTPUT INSERTED.IdProductWarehouse VALUES(@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @CreatedAt)", con);
        cmd.Parameters.AddWithValue("@IdWarehouse", idWarehouse);
        cmd.Parameters.AddWithValue("@IdProduct", idProduct);
        cmd.Parameters.AddWithValue("@IdOrder", idOrder);
        cmd.Parameters.AddWithValue("@Amount", amount);
        cmd.Parameters.AddWithValue("@CreatedAt", createdAt);
        cmd.Parameters.AddWithValue("@Price", price);

        int insertedId = (int)cmd.ExecuteScalar();
        return insertedId;
    }
}