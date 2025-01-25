using CQRSMediaTR.API.Data;
using CQRSMediaTR.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTR.API.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProductAsync(Product product)
        {
            var result = await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var result = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                return 0;
            }
            _context.products.Remove(result);
            await _context.SaveChangesAsync();
            return result.Id;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var result = await _context.products.FirstOrDefaultAsync(x => x.Id == id);
            if (result is null) return null;
            return result;
        }

        public async Task<List<Product>> GetProductListAsync()
        {
            var result = await _context.products.ToListAsync();
            return result;
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            _context.products.Update(product);
            return await _context.SaveChangesAsync();
        }
    }
}
