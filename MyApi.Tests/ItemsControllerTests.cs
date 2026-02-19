using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyApi.Controllers;
using MyApi.Services;
using Xunit;

namespace MyApi.Tests;

public class ItemsControllerTests
{
    [Fact]
    public void Get_ReturnOkResult_WithListOfItems()
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
