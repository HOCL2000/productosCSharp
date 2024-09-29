using backend.Data.Models;

namespace backend.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(string id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(string id, Product product);
        Task<bool> DeleteProductAsync(string id);

    }
}
