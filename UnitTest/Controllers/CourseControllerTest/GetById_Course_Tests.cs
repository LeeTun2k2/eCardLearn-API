using API.Controllers;
using API.Data.DTOs.Course;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Controllers.CourseControllerTest
{
    public class GetById_Course_Tests
    {
        private readonly Mock<ICourseService> _mockService;
        private readonly CourseController _controller;
        private readonly Mock<ILogger<CourseController>> _mockLogger;

        public GetById_Course_Tests()
        {
            _mockService = new Mock<ICourseService>();
            _mockLogger = new Mock<ILogger<CourseController>>();
            var userManager = MockUserManager.Mock_UserManager();
            var controllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.CreateMockHttpContext(() => "00000000-0000-0000-0000-000000000001")
            };

            _controller = new CourseController(_mockService.Object, _mockLogger.Object, userManager)
            {
                ControllerContext = controllerContext
            };
        }

        [Fact]
        public async Task Course_GetById_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expecteds = new CourseViewModel{ CourseId = id };

            _mockService.Setup(service => service.GetById(id)).ReturnsAsync(expecteds);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result);
            var objectResult = (OkObjectResult)result;
            Assert.Equal(200, objectResult.StatusCode);

            var model = objectResult.Value as CourseViewModel;

            if (model == null)
            {
                Assert.Fail("Null value");
                return;
            }

            Assert.Equal(expecteds, model);
        }

        [Fact]
        public async Task Course_GetById_ReturnsNotFoundResult()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService.Setup(service => service.GetById(id)).ReturnsAsync((CourseViewModel)null!);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<NotFoundResult>(result);
            var notFoundResult = (NotFoundResult)result;
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task Course_GetById_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService.Setup(service => service.GetById(id)).Throws(new Exception("Simulated exception"));

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }
    }
}
