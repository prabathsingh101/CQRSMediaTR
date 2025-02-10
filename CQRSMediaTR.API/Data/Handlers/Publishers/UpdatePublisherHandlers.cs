using CQRSMediaTR.API.Data.Command.Publishers;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Publishers
{
    public class UpdatePublisherHandlers : IRequestHandler<UpdatePublisherCommand, int>
    {
        private readonly IPublishersRepository _publishers;

        public UpdatePublisherHandlers(IPublishersRepository publishers)
        {
            _publishers = publishers;
        }
        public async Task<int> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            Publisher author = new Publisher()
            {
                PublisherID = request.PublisherID,
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                UpdatedBy = 3,
                UpdatedDate = DateTime.UtcNow,
            };
            return await _publishers.UpdatePublisherAsync(author);
        }
    }
}
