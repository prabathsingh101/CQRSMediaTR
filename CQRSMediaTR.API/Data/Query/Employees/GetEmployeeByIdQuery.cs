using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data.Query.Employees
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
