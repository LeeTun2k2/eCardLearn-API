using API.Controllers;
using API.Data.DTOs.StudentJoinTest;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Controllers.StudentJoinTestControllerTest
{
    public class Get_StudentJoinTest_Tests
    {
        private readonly Mock<IStudentJoinTestService> _mockService;
        private readonly StudentJoinTestController _controller;
        private readonly Mock<ILogger<StudentJoinTestController>> _mockLogger;

        public Get_StudentJoinTest_Tests()
        {
            _mockService = new Mock<IStudentJoinTestService>();
            _mockLogger = new Mock<ILogger<StudentJoinTestController>>();
            var userManager = MockUserManager.Mock_UserManager();
            var controllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.CreateMockHttpContext(() => "00000000-0000-0000-0000-000000000001")
            };

            _controller = new StudentJoinTestController(_mockService.Object, _mockLogger.Object, userManager)
            {
                ControllerContext = controllerContext
            };
        }

        [Fact]
        public async Task StudentJoinTest_Get_ReturnsOkResult()
        {
            // Arrange
            var filters = new StudentJoinTestFilterModel();
            var expecteds = new List<StudentJoinTestViewModel>
            {
                new StudentJoinTestViewModel(),
                new StudentJoinTestViewModel()
            };

            _mockService.Setup(service => service.GetAsync(filters)).ReturnsAsync(expecteds);

            // Act
            var result = await _controller.Get(filters);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result);
            var objectResult = (OkObjectResult)result;
            Assert.Equal(200, objectResult.StatusCode);

            var models = objectResult.Value as IEnumerable<StudentJoinTestViewModel>;

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
            var filter = new StudentJoinTestFilterModel();

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
