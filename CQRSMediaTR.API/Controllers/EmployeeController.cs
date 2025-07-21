using CQRSMediaTR.API.Data.Command.Employees;
using CQRSMediaTR.API.Data.Query.Employees;
using CQRSMediaTR.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CQRSMediaTR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("AllEmployee")]
        [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
        public async Task<List<Employee>> GetAllEmployee()
        {
            var employeeList = await _mediator.Send(new GetEmployeeListQuery());
            if (employeeList == null) return null;
            return employeeList;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
            if (employee is null) return null;
            return Ok(employee);
        }

        [HttpPost]
        [Route("POST")]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            var employeeReturn = await _mediator.Send(
                new CreateEmployeeCommand(employee.Name, employee.Email, employee.Phone, employee.Address));

            if (employeeReturn is null) return BadRequest();
            return Ok(employeeReturn);
        }

        [HttpPut]
        [Route("PUT")]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            var result = await _mediator.Send(
                new UpdateEmployeeCommand(
                    employee.Id, 
                    employee.Name, 
                    employee.Email, 
                    employee.Phone, 
                    employee.Address)
                );
            if (result == null) return BadRequest();
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(
                new DeleteEmployeeCommand() { Id = id });
            if (result == null) { return BadRequest(); }
            return Ok(result);
        }
    }
}
