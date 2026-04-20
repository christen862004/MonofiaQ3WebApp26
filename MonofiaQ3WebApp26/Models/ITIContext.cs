using Microsoft.EntityFrameworkCore;

namespace MonofiaQ3WebApp26.Models
{
    public class ITIContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }

        public ITIContext():base()
        {
            //DBContextOptions
            //DBMS
            //server name
            //auth (username ,pass ) window
            //db name

        }
        //public ITIContext(DbContextOptions<ITIContext> options):base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ManQ3_26;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
