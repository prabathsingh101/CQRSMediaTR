using CQRSMediaTR.API.Models;

namespace CQRSMediaTR.API.Services
{
    public interface IPublishersRepository
    {
        public Task<List<Publisher>> GetPublisherListAsync();
        public Task<Publisher> GetPublisherByIdAsync(int id);
        public Task<Publisher> AddPublisherAsync(Publisher publisher);
        public Task<int> UpdatePublisherAsync(Publisher publisher);
        public Task<int> DeletePublisherAsync(int id);
    }
}
