using Microsoft.EntityFrameworkCore;

namespace MyApi.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

    // This creates the "Items" table in Postgres
    public DbSet<ItemEntity> Items { get; set; }
}

public class ItemEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}