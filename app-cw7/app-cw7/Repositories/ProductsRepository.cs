using System.Data.SqlClient;
using app_cw7.Models;

namespace app_cw7.Repositories;

public class ProductsRepository : IProductsRepository
{
    private readonly string _connectionString;

    public ProductsRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public Product getProduct(int id)
    {
        using var con = new SqlConnection(_connectionString);
        con.Open();

        using SqlCommand cmd = new SqlCommand("SELECT IdProduct,Name,Description,Price FROM Product WHERE IdProduct = @IdProduct", con);
        cmd.Parameters.AddWithValue("@IdProduct", id);
        
        var reader = cmd.ExecuteReader();

        Product product;
        if (reader.Read())
        {
            product = new Product
            {
                ProductId = (int)reader["IdProduct"],
                Description = reader["Description"].ToString(),
                Name = reader["Name"].ToString(),
                Price = (decimal)reader["Price"]
            };
        }
        else
        {
            product = null;
        }

        return product;
    }
}