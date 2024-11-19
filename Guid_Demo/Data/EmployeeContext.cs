using Guid_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Guid_Demo.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) 
        { }
    }
}
