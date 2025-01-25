using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Query
{
    public class GetProductListQuery : IRequest<List<Product>>
    {
    }
}
