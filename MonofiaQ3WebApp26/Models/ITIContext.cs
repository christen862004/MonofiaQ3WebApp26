using Microsoft.EntityFrameworkCore;

namespace MonofiaQ3WebApp26.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        public ITIContext(DbContextOptions<ITIContext> options):base(options) { }//inject
      
    }
}
