using CQRSMediaTR.API.Data.Query.Authors;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Authors
{
    public class GetAuthorListHandlers : IRequestHandler<GetAuthorListQuery, List<Author>>
    {
        private readonly IAuthorRepository _repository;

        public GetAuthorListHandlers(IAuthorRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Author>> Handle(GetAuthorListQuery request, 
            CancellationToken cancellationToken)
        {
            var result = _repository.GetAuthorListAsync();
            if (result == null) { return default; }
            return await result;
        }
    }
}
