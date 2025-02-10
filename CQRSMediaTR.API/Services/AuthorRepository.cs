using CQRSMediaTR.API.Data;
using CQRSMediaTR.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTR.API.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Author> AddAuthorAsync(Author author)
        {
            var result = await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteAuthorAsync(int id)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
            if (result == null)
            {
                return 0;
            }
            _context.Authors.Remove(result);
            await _context.SaveChangesAsync();
            return result.AuthorId;
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == id);
            if (result is null) return null;
            return result;
        }

        public async Task<List<Author>> GetAuthorListAsync()
        {
            var result = await _context.Authors.ToListAsync();
            return result;
        }

        public async Task<int> UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            return await _context.SaveChangesAsync();
        }
    }
}
