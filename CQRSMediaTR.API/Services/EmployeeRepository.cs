using CQRSMediaTR.API.Data;
using CQRSMediaTR.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTR.API.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var result = await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (result == null) {
                return 0;
            }
            _context.Employees.Remove(result);
            await _context.SaveChangesAsync();
            return result.Id;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if(result is null) return null;
            return result;
        }

        public async Task<List<Employee>> GetEmployeeListAsync()
        {
           var result= await _context.Employees.ToListAsync();
            return result;  
        }

        public async Task<int> UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync();
        }
    }
}
