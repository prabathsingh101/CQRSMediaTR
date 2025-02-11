using CQRSMediaTR.API.Data.Command.Publishers;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Publishers
{
    public class CreatePublisherHandlers : IRequestHandler<CreatePublisherCommand, Publisher>
    {
        private readonly IPublishersRepository _publishers;

        public CreatePublisherHandlers(IPublishersRepository publishers)
        {
            _publishers = publishers;
        }
        public async Task<Publisher> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            Publisher publisher = new Publisher()
            {
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                CreatedBy = 3,
            };
            return await _publishers.AddPublisherAsync(publisher);
        }
    }
}
