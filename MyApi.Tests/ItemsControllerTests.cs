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
    public void UpdateReturnsNoContentWhenOperationIsCompleted()
    {
        // Arrange
        var mockService = new Mock<IItemService>();
        var controller = new ItemsController(mockService.Object);
        // Act
        var result = controller.Patch(4, "keyboard");
        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void Delete_ReturnsNoContent_WhenItemExists()
    {
        // Arrange
        var mockService = new Mock<IItemService>();
        var controller = new ItemsController(mockService.Object);
        // Act
        var result = controller.Delete(4);
        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public void Delete_ReturnsNotFound_WhenServiceThrowsKeyNotFound()
    {
        var mockService = new Mock<IItemService>();
        mockService.Setup(s => s.Delete(It.IsAny<int>())).Throws<KeyNotFoundException>();
        var controller = new ItemsController(mockService.Object);

        var result = controller.Delete(4);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Update_ReturnsNotFound_WhenServiceThrowsKeyNotFound()
    {
        var mockService = new Mock<IItemService>();
        mockService.Setup(s => s.Update(It.IsAny<int>(), It.IsAny<string>())).Throws<KeyNotFoundException>();
        var controller = new ItemsController(mockService.Object);

        var result = controller.Patch(4, "NewItem");
    Assert.IsType<NotFoundResult>(result);
    }
}
