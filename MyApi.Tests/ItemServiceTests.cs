using MyApi.Data;
using MyApi.Services;

namespace MyApi.Tests;

public class ItemServiceTests : TestBase
{
    [Fact]
    public void TestIfGetAllReturnsItems()
    {
        // Arrange
        var context = GetDbContext();
        var service = new ItemService(context);
        
        // Act
        service.Add("New Item");
        
        // Assert
        Assert.Contains("New Item", service.GetAll());
    }

    [Fact]
    public void TestIfPostAddsItem()
    {
        // Arrange
        var context = GetDbContext();
        var service = new ItemService(context);
        
        var newItem = "Keyboard";

        // Act
        service.Add(newItem);
        

        // Assert
        Assert.Single(service.GetAll());
        Assert.Contains("Keyboard", service.GetAll());
    }

    [Fact]
    public void TestIfItemIsDeleted()
    {
        // Arrange
        var context = GetDbContext();
        var service = new ItemService(context);
        
        service.Add("Mouse");
        var itemInDb = context.Items.First(i => i.Name == "Mouse");
        int mouseId = itemInDb.Id;
        
        // Act
        service.Delete(mouseId);

        // Assert
        var allItems = service.GetAll();
        Assert.DoesNotContain("Mouse", allItems);

    }

    [Fact]
    public void TestIfItemIsUpdated()
    {
        // Arrange
        var context = GetDbContext();
        var service = new ItemService(context);
        
        service.Add("Laptop");
        var itemInDb = context.Items.First(i => i.Name == "Laptop");
        int laptopId = itemInDb.Id;

        // Act
        service.Update(laptopId, "Monitor");
        

        // Assert
        var allItems = service.GetAll();
        Assert.Contains("Monitor", allItems);
        Assert.DoesNotContain("Laptop", allItems);
    }

    [Fact]
    public void Update_ShouldThrowException_WhenItemNotFound()
    {
        // Arrange
        var context = GetDbContext();
        var service = new ItemService(context);
        
        // Act
        
        
        
        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => service.Update(1, "Monitor"));
    }
}
