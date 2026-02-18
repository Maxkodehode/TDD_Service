using Xunit;

namespace MyApi.Tests;

public class ItemTest
{
    [Fact]
    public void Test1()
    {
        var service = new ItemService();
        var items = service.GetAll();

        Assert.NotNull(items);
    }
}
