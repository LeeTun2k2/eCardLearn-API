using API.Controllers;
using API.Data.DTOs.Notification;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Controllers.NotificationControllerTest
{
    public class Update_Notification_Tests
    {
        private readonly Mock<INotificationService> _mockService;
        private readonly NotificationController _controller;
        private readonly Mock<ILogger<NotificationController>> _mockLogger;

        public Update_Notification_Tests()
        {
            _mockService = new Mock<INotificationService>();
            _mockLogger = new Mock<ILogger<NotificationController>>();
            var userManager = MockUserManager.Mock_UserManager();
            var controllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.CreateMockHttpContext(() => "00000000-0000-0000-0000-000000000001")
            };

            _controller = new NotificationController(_mockService.Object, _mockLogger.Object, userManager)
            {
                ControllerContext = controllerContext
            };
        }

        [Fact]
        public async Task Notification_Update_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new NotificationEditModel
            {
                NotificationId = id,
            };

            var existingEntity = new NotificationViewModel
            {
                NotificationId = id,
                CreatedUserId = Guid.NewGuid(),
                CreatedDate = DateTime.Today,
            };

            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(existingEntity);
            _mockService.Setup(service => service.UpdateAsync(id, model)).ReturnsAsync(new NotificationViewModel { NotificationId = id });

            // Act
            var result = await _controller.Update(id, model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = (OkObjectResult)result;
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);

            var updatedModel = Assert.IsType<NotificationViewModel>(okObjectResult.Value);
            Assert.NotNull(updatedModel);
            Assert.Equal(id, updatedModel.NotificationId);
        }

        [Fact]
        public async Task Notification_Update_ReturnsBadRequestResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new NotificationEditModel
            {
                NotificationId = id,
            };

            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((NotificationViewModel)null!);

            // Act
            var result = await _controller.Update(id, model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<NotFoundResult>(result);
            var notFoundResult = (NotFoundResult)result;
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task Notification_Update_ReturnsBadRequestWhenIdMismatch()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new NotificationEditModel
            {
                NotificationId = Guid.NewGuid(),
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
        public async Task Notification_Update_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new NotificationEditModel
            {
                NotificationId = id,
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
