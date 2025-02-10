using MediatR;

namespace CQRSMediaTR.API.Data.Command.Publishers
{
    public class DeletePublisherCommand:IRequest<int>
    {
        public int PublisherId { get; set; } 
    }
}
