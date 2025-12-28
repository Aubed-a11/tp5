using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TP08.Repositories.Interfaces;
using TP08.Models.Entities;

namespace TP08.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ProductModel>> GetAllProductsAsync()
        {
            var products = new List<ProductModel>();

            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("SELECT * FROM Product", conn);

            await conn.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                products.Add(new ProductModel
                {
                    Id = reader.GetInt16(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDouble(2)
                });
            }

            return products;
        }

        public async Task<ProductModel?> GetProductByIdAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand("SELECT * FROM Product WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            await conn.OpenAsync();
            var reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new ProductModel
                {
                    Id = reader.GetInt16(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDouble(2)
                };
            }

            return null;
        }

        public async Task AddProductAsync(string name, float price)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(
                "INSERT INTO Product(name, price) VALUES(@name, @price)", conn);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);

            await conn.OpenAsync();
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<bool> UpdateProductAsync(int id, string name, float price)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(
                "UPDATE Product SET name=@name, price=@price WHERE id=@id", conn);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            using var conn = new SqlConnection(_connectionString);
            var cmd = new SqlCommand(
                "DELETE FROM Product WHERE id=@id", conn);

            cmd.Parameters.AddWithValue("@id", id);

            await conn.OpenAsync();
            return await cmd.ExecuteNonQueryAsync() > 0;
        }
    }
}
