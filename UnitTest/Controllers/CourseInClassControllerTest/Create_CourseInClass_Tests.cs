using API.Controllers;
using API.Data.DTOs.CourseInClass;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Controllers.CourseInClassControllerTest
{
    public class Create_CourseInClass_Tests
    {
        private readonly Mock<ICourseInClassService> _mockService;
        private readonly CourseInClassController _controller;
        private readonly Mock<ILogger<CourseInClassController>> _mockLogger;

        public Create_CourseInClass_Tests()
        {
            _mockService = new Mock<ICourseInClassService>();
            _mockLogger = new Mock<ILogger<CourseInClassController>>();
            var userManager = MockUserManager.Mock_UserManager();
            var controllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.CreateMockHttpContext(() => "00000000-0000-0000-0000-000000000001")
            };

            _controller = new CourseInClassController(_mockService.Object, _mockLogger.Object, userManager)
            {
                ControllerContext = controllerContext
            };
        }

        [Fact]
        public async Task CourseInClass_Create_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var model = new CourseInClassAddModel
            {
                // Initialize properties of your model for testing
            };

            _mockService.Setup(service => service.AddAsync(model)).ReturnsAsync(new CourseInClassViewModel { CourseInClassId = Guid.NewGuid() });

            // Act
            var result = await _controller.Create(model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<CreatedAtActionResult>(result);
            var createdAtActionResult = (CreatedAtActionResult)result;
            Assert.Equal(StatusCodes.Status201Created, createdAtActionResult.StatusCode);
            Assert.Equal(nameof(_controller.Create), createdAtActionResult.ActionName);

            var routeValues = Assert.IsType<CourseInClassViewModel>(createdAtActionResult.Value);
            Assert.NotNull(routeValues);
        }

        [Fact]
        public async Task CourseInClass_Create_ReturnsBadRequestResult()
        {
            // Arrange
            var model = new CourseInClassAddModel
            {
                // Initialize properties of your model for testing
            };

            _mockService.Setup(service => service.AddAsync(model)).ReturnsAsync((CourseInClassViewModel)null!);

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
        public async Task CourseInClass_Create_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var model = new CourseInClassAddModel
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
