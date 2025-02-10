using CQRSMediaTR.API.Data.Query.Authors;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Authors
{
    public class GetAuthorHandlers : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly IAuthorRepository _repository;

        public GetAuthorHandlers(IAuthorRepository repository)
        {
            _repository = repository;
        }
        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var isExists =  _repository.GetAuthorByIdAsync(request.AuthorId);
            if (isExists == null) { return default; }
            return await isExists;
        }
    }
}
