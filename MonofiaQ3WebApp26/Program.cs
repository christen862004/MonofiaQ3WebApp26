using MonofiaQ3WebApp26.Repository;

namespace MonofiaQ3WebApp26
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. ay7
            //1) built in service (interface,class) already register
            //2) built in service (interface,class) need to register
            builder.Services.AddControllersWithViews();

            //3) cutom serviuce (repo) ,need to register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //builder.Services.AddScoped<IService, Service>();
            var app = builder.Build();













            // Configure the HTTP request pipeline.  mileware ay6
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
