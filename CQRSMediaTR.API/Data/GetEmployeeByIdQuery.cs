using CQRSMediaTR.API.Models;
using MediatR;

namespace CQRSMediaTR.API.Data
{
    public class GetEmployeeByIdQuery:IRequest<Employee>
    {
        public int Id { get; set; }
    }
}
