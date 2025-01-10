using CQRSMediaTR.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSMediaTR.API.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }  
    }
}
