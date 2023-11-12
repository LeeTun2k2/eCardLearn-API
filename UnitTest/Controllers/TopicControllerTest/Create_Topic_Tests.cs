using API.Controllers;
using API.Data.DTOs.Topic;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Controllers.TopicControllerTest
{
    public class Create_Topic_Tests
    {
        private readonly Mock<ITopicService> _mockService;
        private readonly TopicController _controller;
        private readonly Mock<ILogger<TopicController>> _mockLogger;

        public Create_Topic_Tests()
        {
            _mockService = new Mock<ITopicService>();
            _mockLogger = new Mock<ILogger<TopicController>>();
            var userManager = MockUserManager.Mock_UserManager();
            var controllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.CreateMockHttpContext(() => "00000000-0000-0000-0000-000000000001")
            };

            _controller = new TopicController(_mockService.Object, _mockLogger.Object, userManager)
            {
                ControllerContext = controllerContext
            };
        }

        [Fact]
        public async Task Topic_Create_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var model = new TopicAddModel
            {
                // Initialize properties of your model for testing
            };

            _mockService.Setup(service => service.AddAsync(model)).ReturnsAsync(new TopicViewModel { TopicId = Guid.NewGuid() });

            // Act
            var result = await _controller.Create(model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<CreatedAtActionResult>(result);
            var createdAtActionResult = (CreatedAtActionResult)result;
            Assert.Equal(StatusCodes.Status201Created, createdAtActionResult.StatusCode);
            Assert.Equal(nameof(_controller.Create), createdAtActionResult.ActionName);

            var routeValues = Assert.IsType<TopicViewModel>(createdAtActionResult.Value);
            Assert.NotNull(routeValues);
        }

        [Fact]
        public async Task Topic_Create_ReturnsBadRequestResult()
        {
            // Arrange
            var model = new TopicAddModel
            {
                // Initialize properties of your model for testing
            };

            _mockService.Setup(service => service.AddAsync(model)).ReturnsAsync((TopicViewModel)null!);

            // Act
            var result = await _controller.Create(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("Can not create object", badRequestResult.Value);
        }

        [Fact]
        public async Task Topic_Create_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var model = new TopicAddModel
            {
                // Initialize properties of your model for testing
            };

            _mockService.Setup(service => service.AddAsync(model)).Throws(new Exception("Simulated exception"));

            // Act
            var result = await _controller.Create(model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }
    }
}
