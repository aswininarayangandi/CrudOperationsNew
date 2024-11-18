using CrudOperations.Data;
using CrudOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperations.Services
{
    public class ProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) { 
            _context = context;
        }
        public async Task<List<Product>> GetProductsAsync() => await _context.products.ToListAsync();

        public async Task<Product> GetProductByIdAsync(int id) => await _context.products.FindAsync(id);
        public async Task AddProductAsync(Product product)
        {
            _context.products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if(product != null)
            {
                _context.products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}
