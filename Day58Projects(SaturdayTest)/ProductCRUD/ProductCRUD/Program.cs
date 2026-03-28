using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Interfaces;
using ProductAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// ─── Services ────────────────────────────────────────────────────────────────

// EF Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// DI: Interface → Service
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = "Product API",
        Version = "v1",
        Description = "Simple CRUD API for Products — built with .NET 8 + EF Core + SQL Server"
    });
});

// CORS (for the HTML UI)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

// ─── App pipeline ─────────────────────────────────────────────────────────────

var app = builder.Build();

// Auto-run migrations & seed on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1");
    c.RoutePrefix = "swagger"; // http://localhost:<port>/swagger
});

app.UseStaticFiles();   // serve wwwroot
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// Redirect root → swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();
