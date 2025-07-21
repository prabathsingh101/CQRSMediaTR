using CQRSMediaTR.API.Data.Command.Authors;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Authors
{
    public class DeleteAuthorHandlers : IRequestHandler<DeleteAuthorCommand, int>
    {
        private readonly IAuthorRepository _repository;

        public DeleteAuthorHandlers(IAuthorRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var isExists = await _repository.GetAuthorByIdAsync(request.AuthorId);
            // Check if the author exists
            if (isExists == null)
            {
                return default;
            }
            else
            {
                return await _repository.DeleteAuthorAsync(request.AuthorId);
            }
        }
    }
}
