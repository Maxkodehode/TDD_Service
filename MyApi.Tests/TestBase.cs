using Microsoft.EntityFrameworkCore;
using MyApi.Data;

namespace MyApi.Tests;

public class TestBase
{
    protected ApiDbContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<ApiDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique name per test
            .Options;

        var context = new ApiDbContext(options);
        context.Database.EnsureCreated();
        return context;
    }
}
