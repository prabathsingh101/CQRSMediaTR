using CQRSMediaTR.API.Models;

namespace CQRSMediaTR.API.Services
{
    public interface IEmployeeRepository
    {
        public Task<List<Employee>> GetEmployeeListAsync();   
        public Task<Employee> GetEmployeeByIdAsync(int id);
        public Task<Employee> AddEmployeeAsync(Employee employee);
        public Task<int> UpdateEmployeeAsync(Employee employee);
        public Task<int> DeleteEmployeeAsync(int id);
    }
}
