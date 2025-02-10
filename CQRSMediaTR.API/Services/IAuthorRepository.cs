using CQRSMediaTR.API.Models;

namespace CQRSMediaTR.API.Services
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAuthorListAsync();
        public Task<Author> GetAuthorByIdAsync(int id);
        public Task<Author> AddAuthorAsync(Author author);
        public Task<int> UpdateAuthorAsync(Author author);
        public Task<int> DeleteAuthorAsync(int id);
    }
}
