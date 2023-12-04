using API.Controllers;
using API.Data.DTOs.CourseInClass;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Controllers.CourseInClassControllerTest
{
    public class Get_CourseInClass_Tests
    {
        private readonly Mock<ICourseInClassService> _mockService;
        private readonly CourseInClassController _controller;
        private readonly Mock<ILogger<CourseInClassController>> _mockLogger;

        public Get_CourseInClass_Tests()
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
        public async Task CourseInClass_Get_ReturnsOkResult()
        {
            // Arrange
            var filters = new CourseInClassFilterModel();
            var expecteds = new List<CourseInClassViewModel>
            {
                new CourseInClassViewModel(),
                new CourseInClassViewModel()
            };

            _mockService.Setup(service => service.GetAsync(filters)).ReturnsAsync(expecteds);

            // Act
            var result = await _controller.Get(filters);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result);
            var objectResult = (OkObjectResult)result;
            Assert.Equal(200, objectResult.StatusCode);

            var models = objectResult.Value as IEnumerable<CourseInClassViewModel>;

            if (models == null)
            {
                Assert.Fail("Null value");
                return;
            }

            Assert.Equal(2, models.Count());
            Assert.Equal(expecteds, models);
        }

        [Fact]
        public async Task Get_ReturnsInternalServerErrorResultOnException()
        {
            // Arrange
            var filter = new CourseInClassFilterModel();

            _mockService.Setup(x => x.GetAsync(filter)).Throws(new Exception("Simulated exception"));

            // Act
            var result = await _controller.Get(filter);

            // Assert
            Assert.IsType<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.Equal(500, objectResult.StatusCode);
            Assert.Equal("Internal Server Error", objectResult.Value);
        }
    }
}
