using MyApi.Services;
using MyApi.Controllers;

namespace MyApi.Tests;

public class ItemServiceTests
{
    [Fact]
    public void TestIfGetAllReturnsItems()
    {
        var service = new ItemService();
        var items = service.GetAll();

        Assert.NotNull(items);
    }

    [Fact]
    public void TestIfPostAddsItem()
    {
        // Arrange
        var service = new ItemService();
        var newItem = "Keyboard";
        
        // Act
        service.Add(newItem);
        var items = service.GetAll();
        
        // Assert
        Assert.Equal(3, items.Count); 
        Assert.Contains("Keyboard", items);
    }
}
