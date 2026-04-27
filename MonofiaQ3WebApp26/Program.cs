using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
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
            builder.Services.AddDbContext<ITIContext>(optionsBuilder => {
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });//registe ITIContext,dbcontextOption 

            builder.Services.AddSession(conf =>
            {
                conf.IdleTimeout = TimeSpan.FromMinutes(30);
            });



            //3) cutom serviuce (repo) ,need to register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //builder.Services.AddScoped<IService, Service>();
            var app = builder.Build();
            #region Custom pipleLine
            //inline Compoent Midleware
            //app.Use(async (httpcontext, nextMiddleware) =>
            //{
            //    await httpcontext.Response.WriteAsync("1) Middleware 1 \n");
            //    await nextMiddleware.Invoke();
            //    await httpcontext.Response.WriteAsync("1-1) Middleware 1-1 \n");

            //});
            //app.Use(async (httpcontext, nextMiddleware) =>
            //{
            //    await httpcontext.Response.WriteAsync("2) Middleware 2 \n");
            //    await nextMiddleware.Invoke();//
            //    await httpcontext.Response.WriteAsync("2-2) Middleware 2-2 \n");

            //});
            //app.Run(async (httpcontext) =>
            //{
            //    await httpcontext.Response.WriteAsync("3) terminate \n");

            //});

            #endregion


            #region  Configure the HTTP request pipeline.  mileware ay6
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//by default search in wwwroot

            app.UseRouting();
           
            app.UseSession();//rea an wriet session ,create user session,inject some service
            
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
