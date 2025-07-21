using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Query.Authors
{
    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public int AuthorId { get; set; }
    }
}
