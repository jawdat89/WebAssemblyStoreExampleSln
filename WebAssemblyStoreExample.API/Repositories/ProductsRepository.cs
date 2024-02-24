using Microsoft.EntityFrameworkCore;
using WebAssemblyStoreExample.API.Data;
using WebAssemblyStoreExample.API.Entities;
using WebAssemblyStoreExample.API.Repositories.Contracts;

namespace WebAssemblyStoreExample.API.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly DataContext _context;
        public ProductsRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            var categories = await _context.ProductCategories.ToListAsync();
            return categories;
        }

        public async Task<ProductCategory> GetCategory(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);

            if (category == null)
            {
                throw new Exception("Category is not exists");
            }

            return category;
        }

        public Task<Product> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }
    }
}
