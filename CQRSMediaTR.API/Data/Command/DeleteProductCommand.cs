using MediatR;

namespace CQRSMediaTR.API.Data.Command
{
    public class DeleteProductCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}
