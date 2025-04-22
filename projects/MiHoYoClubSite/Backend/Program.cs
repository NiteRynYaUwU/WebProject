using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MiHoYoClubSite.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Enable CORS first
app.UseCors("AllowAll");

// Serve index.html at root and other static files under wwwroot
app.UseDefaultFiles();    // looks for index.html by default
app.UseStaticFiles();     // serves CSS, JS, images, HTML, etc.

// Map your API controllers under /api
app.MapControllers();

app.Run();
