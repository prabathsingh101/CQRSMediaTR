using CQRSMediaTR.API.Data.Command.Products;
using CQRSMediaTR.API.Data.Command.Publishers;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers.Publishers
{
    public class DeletePublisherHandlers : IRequestHandler<DeletePublisherCommand, int>
    {
        private readonly IPublishersRepository _publishers;

        public DeletePublisherHandlers(IPublishersRepository publishers)
        {
           _publishers = publishers;
        }
        public async Task<int> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            var isExists = await _publishers.GetPublisherByIdAsync(request.PublisherId);
            if (isExists == null)
            {
                return default;
            }
            else
            {
                return await _publishers.DeletePublisherAsync(request.PublisherId);
            }
        }
    }
}
