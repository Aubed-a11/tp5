using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP08.Models.Dtos;
using TP08.Repositories.Interfaces;
using TP08.Models.Dtos;

namespace TP08.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllProductsAsync();
            return products.Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price
            });
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            if (product == null) return null;

            return new ProductDto
            {
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task AddAsync(ProductDto dto)
        {
            await _repo.AddProductAsync(dto.Name, (float)dto.Price);
        }

        public async Task<bool> UpdateAsync(int id, ProductDto dto)
        {
            return await _repo.UpdateProductAsync(id, dto.Name, (float)dto.Price);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repo.DeleteProductAsync(id);
        }
    }
}
