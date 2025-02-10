using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Query.Publishers
{
    public class GetPublishersListQuery:IRequest<List<Publisher>>
    {
    }
}
