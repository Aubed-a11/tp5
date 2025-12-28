using System.Collections.Generic;
using System.Threading.Tasks;
using TP08.Models.Entities;

namespace TP08.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAllProductsAsync();

        Task<ProductModel?> GetProductByIdAsync(int id);

        Task AddProductAsync(string name, float price);

        Task<bool> UpdateProductAsync(int id, string name, float price);

        Task<bool> DeleteProductAsync(int id);
    }
}
