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

            return category;
        }

        public async Task<Product> GetItem(int id)
        {
            var product = await _context.Products
                                    .Include(p => p.ProductCategory)
                                    .SingleOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetItems()
        {
            var products = await _context.Products
                                  .Include(p => p.ProductCategory)
                                  .ToListAsync();

            return products;
        }

        public async Task<IEnumerable<Product>> GetItemsByCategory(int id)
        {
            var products = await _context.Products
                                   .Include(p => p.ProductCategory)
                                   .Where(p => p.CategoryId == id)
                                   .ToListAsync();

            return products;
        }
    }
}
