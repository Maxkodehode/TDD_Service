using MyApi.Services;
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

    [Fact]
    public void TestIfItemIsDeleted()
    {
        // Arrange
        var service = new ItemService();
        
        // Act
        
        var items = service.GetAll();
        service.Delete("Mouse");
        
        
        // Assert
        Assert.DoesNotContain("Mouse", items);
        Assert.Equal(2, items.Count);
    }

    [Fact]
    public void TestIfItemIsUpdated()
    {
        // Arrange
        var service = new ItemService();

    
        // Act
        service.Update("Laptop", "Monitor");
        var items = service.GetAll();
    
        // Assert
        Assert.Contains("Laptop", service.GetAll());
        Assert.Contains("Monitor", items[0]);
        Assert.DoesNotContain("Laptop", items);
    }
}
