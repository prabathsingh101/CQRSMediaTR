using MediatR;

namespace CQRSMediaTR.API.Data.Command.Products
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
