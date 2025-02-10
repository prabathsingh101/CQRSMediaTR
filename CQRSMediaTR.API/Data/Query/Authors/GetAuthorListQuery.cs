using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Query.Authors
{
    public class GetAuthorListQuery:IRequest<List<Author>>
    {
    }
}
