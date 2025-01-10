using MediatR;

namespace CQRSMediaTR.API.Data.Command
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
