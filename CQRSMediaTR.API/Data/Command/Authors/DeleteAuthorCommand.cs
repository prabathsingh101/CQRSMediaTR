using MediatR;

namespace CQRSMediaTR.API.Data.Command.Authors
{
    public class DeleteAuthorCommand:IRequest<int>
    {
        public int AuthorId { get; set; }
    }
}
