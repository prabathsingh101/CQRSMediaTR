using CQRSMediaTR.API.Data.Command;
using CQRSMediaTR.API.Models;
using CQRSMediaTR.API.Services;
using MediatR;

namespace CQRSMediaTR.API.Data.Handlers
{
    public class CreateEmployeeHandlers: IRequestHandler<CreateEmployeeCommand, Employee>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeHandlers(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee()
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address,
            };
            return await _employeeRepository.AddEmployeeAsync(employee);    
        }
    }
}
