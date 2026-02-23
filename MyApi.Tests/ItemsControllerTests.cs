using Microsoft.AspNetCore.Mvc;
using Moq;
using MyApi.Controllers;
using MyApi.Services;


namespace MyApi.Tests;

public class ItemsControllerTests
{
    [Fact]
    public void Get_ReturnsOkObjectResult_WhenCalled()
    {
        // Arrange
        var mockService = new Mock<IItemService>();
        var controller = new ItemsController(mockService.Object);

        // Act
        var result = controller.Get();

        // Assert
        Assert.IsType<OkObjectResult>(result);

    }

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

    [Fact]
    public void Delete_ReturnsNoContent_WhenItemExists()
    {

        // Arrange
        var mockService = new Mock<IItemService>();
        var controller = new ItemsController(mockService.Object);
        // Act
        var result = controller.Delete("mouse");
        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void UpdateReturnsNoContentWhenOperationIsCompleted()
    {
        // Arrange
        var mockService = new Mock<IItemService>();
        var controller = new ItemsController(mockService.Object);
        // Act
        var result = controller.Patch("mouse", "keyboard");
        // Assert
        Assert.IsType<NoContentResult>(result);
    }

}
