using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using MonofiaQ3WebApp26.Filtters;
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
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new HandelErrorAttribute());//global filter
            //});
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ITIContext>(optionsBuilder => {
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });//registe ITIContext,dbcontextOption 
            builder.Services.AddIdentity<AppliactionUser, IdentityRole>()
                .AddEntityFrameworkStores<ITIContext>();

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

            app.UseRouting();//security (mapping)
           
            app.UseSession();//rea an wriet session ,create user session,inject some service
            
            app.UseAuthorization();
            #region Custom route , route constrint using Naming Convention Route
            //route fro each controller "action placeholer"
            //app.MapControllerRoute(name:"route1"
            //    ,pattern: "{controller=Employee}/{action=index}/{id?}");


            //route for each action
            //app.MapControllerRoute(name: "route1", pattern: "r1/{age:int:range(20,60)}/{name?}",
            //    defaults: new { controller = "Route", action = "Method1" });

            //app.MapControllerRoute(name: "route2", pattern: "r2",
            //   defaults: new { controller = "Route", action = "Method2" });
            #endregion
            //staff decalre,execute
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion
            app.Run();
        }
    }
}
