using CQRSMediaTR.API.Data.Command.Authors;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Authors
{
    public class CreateAuthorHandlers : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateAuthorHandlers(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            Author author = new Author()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedBy = 3,  
            };
            return await _authorRepository.AddAuthorAsync(author); 
        }
    }
}
