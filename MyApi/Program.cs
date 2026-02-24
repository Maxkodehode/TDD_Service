using MyApi.Data;
using MyApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. REGISTER THE DATABASE (Must be BEFORE builder.Build())
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. REGISTER THE SERVICE
builder.Services.AddScoped<IItemService, ItemService>();

builder.Services.AddControllers();

var app = builder.Build();

// 3. AUTO-CREATE DATABASE (Must be AFTER builder.Build())
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    db.Database.EnsureCreated();
}

app.UseAuthorization();
app.MapControllers();
app.Run();