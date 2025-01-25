using MediatR;

namespace CQRSMediaTR.API.Data.Command.Employees
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
