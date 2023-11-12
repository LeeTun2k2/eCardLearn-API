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
    public class Update_Topic_Tests
    {
        private readonly Mock<ITopicService> _mockService;
        private readonly TopicController _controller;
        private readonly Mock<ILogger<TopicController>> _mockLogger;

        public Update_Topic_Tests()
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
        public async Task Topic_Update_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new TopicEditModel
            {
                TopicId = id,
            };

            var existingEntity = new TopicViewModel
            {
                TopicId = id,
                CreatedUserId = Guid.NewGuid(),
                CreatedDate = DateTime.Today,
            };

            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(existingEntity);
            _mockService.Setup(service => service.UpdateAsync(id, model)).ReturnsAsync(new TopicViewModel { TopicId = id });

            // Act
            var result = await _controller.Update(id, model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = (OkObjectResult)result;
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);

            var updatedModel = Assert.IsType<TopicViewModel>(okObjectResult.Value);
            Assert.NotNull(updatedModel);
            Assert.Equal(id, updatedModel.TopicId);
        }

        [Fact]
        public async Task Topic_Update_ReturnsBadRequestResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new TopicEditModel
            {
                TopicId = id,
            };

            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((TopicViewModel)null!);

            // Act
            var result = await _controller.Update(id, model);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<NotFoundResult>(result);
            var notFoundResult = (NotFoundResult)result;
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task Topic_Update_ReturnsBadRequestWhenIdMismatch()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new TopicEditModel
            {
                TopicId = Guid.NewGuid(),
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
        public async Task Topic_Update_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var model = new TopicEditModel
            {
                TopicId = id,
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
