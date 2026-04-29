using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MonofiaQ3WebApp26.Models
{
    public class ITIContext:IdentityDbContext<AppliactionUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        public ITIContext(DbContextOptions<ITIContext> options):base(options) { }//inject
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //   base.OnModelCreating(builder);
        //}

    }
}
