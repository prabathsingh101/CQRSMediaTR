using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Query.Products
{
    public class GetProductListQuery : IRequest<List<Product>>
    {
    }
}
