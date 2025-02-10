using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Query.Publishers
{
    public class GetPublishersByIdQuery:IRequest<Publisher>
    {
        public int PublisherID { get; set; }
    }
}
