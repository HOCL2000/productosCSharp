using backend.Data.Models;
using backend.Data.Repositories.Interfaces;
using MongoDB.Driver;

namespace backend.Data.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductsRepository()
        {
            // Cambia la conexión por tu string de conexión a MongoDB
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("productosTaliznay");
            _products = database.GetCollection<Product>("products");
        }

        // Crear un nuevo producto
        public async Task CreateProductAsync(Product product)
        {
            await _products.InsertOneAsync(product);
        }

        // Obtener todos los productos
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _products.Find(product => true).ToListAsync();
        }

        // Obtener un producto por su ID
        public async Task<Product?> GetProductByIdAsync(string id)
        {
            return await _products.Find<Product>(product => product.Id == id).FirstOrDefaultAsync();
        }

        // Actualizar un producto
        public async Task UpdateProductAsync(string id, Product updatedProduct)
        {
            await _products.ReplaceOneAsync(product => product.Id == id, updatedProduct);
        }

        // Eliminar un producto
        public async Task<bool> DeleteProductAsync(string id)
        {
            var result = await _products.DeleteOneAsync(product => product.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
