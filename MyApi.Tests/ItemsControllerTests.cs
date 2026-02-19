using Microsoft.AspNetCore.Mvc;
using Moq;
using MyApi.Controllers;
using MyApi.Services;


namespace MyApi.Tests;

public class ItemsControllerTests
{
    [Fact]
    public void Post_ReturnsCreatedAtAction_WhenItemIsValid()
    {
        // Arrange

        var mockService = new Mock<IItemService>();
        var controller = new ItemsController(mockService.Object);
        var newItem = "Keyboard";

        // Act
        var result = controller.Post(newItem);

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
        mockService.Verify(s => s.Add("Keyboard"), Times.Once);
    }
}
