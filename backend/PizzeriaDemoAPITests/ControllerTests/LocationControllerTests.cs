using PizzeriaDemoAPI.Controllers;
using PizzeriaDemoAPI.Models;
using PizzeriaDemoAPI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace PizzeriaDemoAPITests;

public class LocationControllerTests
{
    private readonly Mock<ILocationService> _mockLocationService;
    private readonly Mock<ILogger<LocationController>> _mockLocationLogger;
    private readonly LocationController _locationController;

    public LocationControllerTests()
    {
        _mockLocationService = new Mock<ILocationService>();
        _mockLocationLogger = new Mock<ILogger<LocationController>>();
        _locationController = new LocationController(_mockLocationService.Object, _mockLocationLogger.Object);
    }

    [Fact]
    public void GetAllLocations_ReturnsOkObjectResult()
    {
        // Arrange
        var expectedLocations = new List<Location>
        {
            new Location { Id = 1, Name = "Town 1" },
            new Location { Id = 2, Name = "Town 2" },
        };
        _mockLocationService.Setup(s => s.GetAllLocations()).Returns(expectedLocations);

        // Act
        var result = _locationController.GetAllLocations();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var actualLocations = Assert.IsAssignableFrom<IEnumerable<Location>>(okResult.Value);
        Assert.Equal(expectedLocations.Count, actualLocations.Count());
    }
}