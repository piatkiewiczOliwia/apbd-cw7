using app_cw7.Models;
using Microsoft.Data.SqlClient;

namespace app_cw7.Repositories;

public class OrdersRepository : IOrdersRepository
{
    private readonly string _connectionString;

    public OrdersRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public Order GetProductInOrderWithAmount(int id, int amount)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();

        using SqlCommand cmd = new SqlCommand("SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt FROM Order WHERE IdProduct = @IdProduct AND Amount = @Amount", con);
        cmd.Parameters.AddWithValue("@IdProduct", id);
        cmd.Parameters.AddWithValue("@Amount", amount);
        
        var reader = cmd.ExecuteReader();

        Order order;
        if (reader.Read())
        {
            order = new Order()
            {
                IdOrder = (int)reader["IdOrder"],
                IdProduct = (int)reader["IdProduct"],
                Amount = (int)reader["Amount"],
                CreatedAt = (DateTime)reader["CreatedAt"],
                FulfilledAt = reader["FulfilledAt"] as DateTime?
            };
        }
        else
        {
            order = null;
        }

        return order;
    }

    public void SetFulfilledAt(int id)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();

        using SqlCommand cmd = new SqlCommand("UPDATE Order SET FulfilledAt=@Date WHERE IdOrder=@IdOrder", con);
        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
        cmd.Parameters.AddWithValue("@IdOrder", id);
    }
}