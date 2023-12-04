using API.Controllers;
using API.Data.DTOs.Feedback;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Controllers.FeedbackControllerTest
{
    public class Create_Feedback_Tests
    {
        private readonly Mock<IFeedbackService> _mockService;
        private readonly FeedbackController _controller;
        private readonly Mock<ILogger<FeedbackController>> _mockLogger;

        public Create_Feedback_Tests()
        {
            _mockService = new Mock<IFeedbackService>();
            _mockLogger = new Mock<ILogger<FeedbackController>>();
            var userManager = MockUserManager.Mock_UserManager();
            var controllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.CreateMockHttpContext(() => "00000000-0000-0000-0000-000000000001")
            };

            _controller = new FeedbackController(_mockService.Object, _mockLogger.Object, userManager)
            {
                ControllerContext = controllerContext
            };
        }

        [Fact]
        public async Task Feedback_Create_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var model = new FeedbackAddModel
            {
                // Initialize properties of your model for testing
            };

            _mockService.Setup(service => service.AddAsync(model)).ReturnsAsync(new FeedbackViewModel { FeedbackId = Guid.NewGuid() });

            // Act
            var result = await _controller.Create(model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<CreatedAtActionResult>(result);
            var createdAtActionResult = (CreatedAtActionResult)result;
            Assert.Equal(StatusCodes.Status201Created, createdAtActionResult.StatusCode);
            Assert.Equal(nameof(_controller.Create), createdAtActionResult.ActionName);

            var routeValues = Assert.IsType<FeedbackViewModel>(createdAtActionResult.Value);
            Assert.NotNull(routeValues);
        }

        [Fact]
        public async Task Feedback_Create_ReturnsBadRequestResult()
        {
            // Arrange
            var model = new FeedbackAddModel
            {
                // Initialize properties of your model for testing
            };

            _mockService.Setup(service => service.AddAsync(model)).ReturnsAsync((FeedbackViewModel)null!);

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
        public async Task Feedback_Create_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var model = new FeedbackAddModel
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
