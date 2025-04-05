using lab2.Models;
using lab2.Repository;
using Microsoft.EntityFrameworkCore;

namespace lab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession((options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(45);
            }));


            builder.Services.AddScoped<ICourse, CourseRepo>();
            builder.Services.AddScoped<ICrsResult, CrsResultRepo>();
            builder.Services.AddScoped<IDepartment, DepartmentRepo>();
            builder.Services.AddScoped<IInstructor, InstructorRepo>();
            builder.Services.AddScoped<ITrainee, TraineeRepo>();


            builder.Services.AddDbContext<databaseContext>(dbContext =>
            {
                dbContext.UseSqlServer(builder.Configuration.GetConnectionString("crsManagment"));
            });

            var app = builder.Build();
            //app.UseSession();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.Run();
        }
    }
}
