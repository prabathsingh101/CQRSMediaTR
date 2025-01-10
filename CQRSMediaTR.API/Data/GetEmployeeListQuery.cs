using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data
{
    public class GetEmployeeListQuery: IRequest<List<Employee>>
    {
    }
}
