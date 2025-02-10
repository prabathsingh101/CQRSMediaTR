using CQRSMediaTR.API.Data.Query.Publishers;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Publishers
{
    public class GetPublisherListHandlers : IRequestHandler<GetPublishersListQuery, List<Publisher>>
    {
        private readonly IPublishersRepository _repository;

        public GetPublisherListHandlers(IPublishersRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Publisher>> Handle(GetPublishersListQuery request, CancellationToken cancellationToken)
        {
            var isExists = _repository.GetPublisherListAsync();
            if (isExists == null) { return default; }
            return await isExists;
        }
    }
}
