using Microsoft.EntityFrameworkCore;
using WebApiInAsp.NetCoreMvcDemo.Data;

namespace WebApiInAsp.NetCoreMvcDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer(); // Required for Swagger
            builder.Services.AddSwaggerGen();           // Adds Swagger support
            builder.Services.AddDbContext<EmpContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
            });
            builder.Services.AddScoped<IEmployee, EmployeeService>();



            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  // ✅ Add this line
                app.UseSwagger();
                app.UseSwaggerUI();

            }
            else
            {
                // Configure the HTTP request pipeline.
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           

            app.UseHttpsRedirection();
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
