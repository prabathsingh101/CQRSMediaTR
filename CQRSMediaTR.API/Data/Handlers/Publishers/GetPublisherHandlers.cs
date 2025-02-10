using CQRSMediaTR.API.Data.Query.Publishers;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Publishers
{
    public class GetPublisherHandlers : IRequestHandler<GetPublishersByIdQuery, Publisher>
    {
        private readonly IPublishersRepository _publishers;

        public GetPublisherHandlers(IPublishersRepository publishers)
        {
            _publishers = publishers;
        }
        public async Task<Publisher> Handle(GetPublishersByIdQuery request, CancellationToken cancellationToken)
        {
            var isExists = _publishers.GetPublisherByIdAsync(request.PublisherID);
            if (isExists == null) { return default; }
            return await isExists;
        }
    }
}
