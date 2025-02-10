using CQRSMediaTR.API.Data.Command.Authors;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Authors
{
    public class UpdateAuthorHandlers : IRequestHandler<UpdateAuthorCommand, int>
    {
        private readonly IAuthorRepository _repository;

        public UpdateAuthorHandlers(IAuthorRepository repository)
        {
           _repository = repository;
        }
        public async Task<int> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetAuthorByIdAsync(request.AuthorId);
            if (author == null) { return default; }
            author.FirstName = request.FirstName;
            author.LastName = request.LastName;
            author.UpdatedDate = request.UpdatedDate;
            author.UpdatedBy = request.UpdatedBy;
            return await _repository.UpdateAuthorAsync(author);
        }
    }
}
