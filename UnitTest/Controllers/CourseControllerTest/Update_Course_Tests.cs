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
    public class Update_Course_Tests
    {
        private readonly Mock<ICourseService> _mockService;
        private readonly CourseController _controller;
        private readonly Mock<ILogger<CourseController>> _mockLogger;

        public Update_Course_Tests()
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
        public async Task Course_Update_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new CourseEditModel
            {
                CourseId = id,
            };

            var existingEntity = new CourseViewModel
            {
                CourseId = id,
                CreatedUserId = Guid.NewGuid(),
                CreatedDate = DateTime.Today,
            };

            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(existingEntity);
            _mockService.Setup(service => service.UpdateAsync(id, model)).ReturnsAsync(new CourseViewModel { CourseId = id });

            // Act
            var result = await _controller.Update(id, model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = (OkObjectResult)result;
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);

            var updatedModel = Assert.IsType<CourseViewModel>(okObjectResult.Value);
            Assert.NotNull(updatedModel);
            Assert.Equal(id, updatedModel.CourseId);
        }

        [Fact]
        public async Task Course_Update_ReturnsBadRequestResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new CourseEditModel
            {
                CourseId = id,
            };

            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((CourseViewModel)null!);

            // Act
            var result = await _controller.Update(id, model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<NotFoundResult>(result);
            var notFoundResult = (NotFoundResult)result;
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task Course_Update_ReturnsBadRequestWhenIdMismatch()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new CourseEditModel
            {
                CourseId = Guid.NewGuid(),
            };

            // Act
            var result = await _controller.Update(id, model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal(StatusCodes.Status400BadRequest, badRequestResult.StatusCode);
            Assert.Equal("ID in the URL does not match the ID in the request body.", badRequestResult.Value);
        }

        [Fact]
        public async Task Course_Update_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new CourseEditModel
            {
                CourseId = id,
            };

            _mockService.Setup(service => service.GetByIdAsync(id)).Throws(new Exception("Simulated exception"));

            // Act
            var result = await _controller.Update(id, model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<ObjectResult>(result);
            var objectResult = (ObjectResult)result;
            Assert.Equal(StatusCodes.Status500InternalServerError, objectResult.StatusCode);
        }
    }
}
