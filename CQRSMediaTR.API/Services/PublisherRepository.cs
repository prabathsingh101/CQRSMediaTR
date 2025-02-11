using CQRSMediaTR.API.Data;
using CQRSMediaTR.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTR.API.Services
{
    public class PublisherRepository : IPublishersRepository
    {
        private readonly ApplicationDbContext _context;

        public PublisherRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Publisher> AddPublisherAsync(Publisher publisher)
        {       

            var result = await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeletePublisherAsync(int id)
        {
            var result = await _context.Publishers.FirstOrDefaultAsync(x => x.PublisherID == id);
            if (result == null)
            {
                return 0;
            }
            _context.Publishers.Remove(result);
            await _context.SaveChangesAsync();
            return result.PublisherID;
        }

        public async Task<Publisher> GetPublisherByIdAsync(int id)
        {
            var result = await _context.Publishers.FirstOrDefaultAsync(x => x.PublisherID == id);
            if (result is null) return null;
            return result;
        }

        public async Task<List<Publisher>> GetPublisherListAsync()
        {
            var result = await _context.Publishers.ToListAsync();
            return result;
        }

        public async Task<int> UpdatePublisherAsync(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            return await _context.SaveChangesAsync();
        }
    }
}
