using API.Controllers;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Controllers.StudentJoinClassControllerTest
{
    public class Delete_StudentJoinClass_Tests
    {
        private readonly Mock<IStudentJoinClassService> _mockService;
        private readonly StudentJoinClassController _controller;
        private readonly Mock<ILogger<StudentJoinClassController>> _mockLogger;

        public Delete_StudentJoinClass_Tests()
        {
            _mockService = new Mock<IStudentJoinClassService>();
            _mockLogger = new Mock<ILogger<StudentJoinClassController>>();
            var userManager = MockUserManager.Mock_UserManager();
            var controllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.CreateMockHttpContext(() => "00000000-0000-0000-0000-000000000001")
            };

            _controller = new StudentJoinClassController(_mockService.Object, _mockLogger.Object, userManager)
            {
                ControllerContext = controllerContext
            };
        }

        [Fact]
        public async Task StudentJoinClass_Delete_ReturnsNoContentResult()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService.Setup(service => service.DeleteAsync(id)).ReturnsAsync(true);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<NoContentResult>(result);
            var noContentResult = (NoContentResult)result;
            Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
        }

        [Fact]
        public async Task StudentJoinClass_Delete_ReturnsNotFoundResult()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService.Setup(service => service.DeleteAsync(id)).ReturnsAsync(false);

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<NotFoundResult>(result);
            var notFoundResult = (NotFoundResult)result;
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task StudentJoinClass_Delete_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService.Setup(service => service.DeleteAsync(id)).Throws(new Exception("Simulated exception"));

            // Act
            var result = await _controller.Delete(id);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }
    }
}
