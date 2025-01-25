using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Query
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {
    }
}
