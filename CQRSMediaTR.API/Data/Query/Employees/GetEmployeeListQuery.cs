using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Query.Employees
{
    public class GetEmployeeListQuery : IRequest<List<Employee>>
    {
    }
}
