using API.Controllers;
using API.Data.DTOs.Answer;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Controllers.AnswerControllerTest
{
    public class GetById_Answer_Tests
    {
        private readonly Mock<IAnswerService> _mockService;
        private readonly AnswerController _controller;
        private readonly Mock<ILogger<AnswerController>> _mockLogger;

        public GetById_Answer_Tests()
        {
            _mockService = new Mock<IAnswerService>();
            _mockLogger = new Mock<ILogger<AnswerController>>();
            var userManager = MockUserManager.Mock_UserManager();
            var controllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.CreateMockHttpContext(() => "00000000-0000-0000-0000-000000000001")
            };

            _controller = new AnswerController(_mockService.Object, _mockLogger.Object, userManager)
            {
                ControllerContext = controllerContext
            };
        }

        [Fact]
        public async Task Answer_GetById_ReturnsOkResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var expecteds = new AnswerViewModel{ AnswerId = id };

            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(expecteds);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<OkObjectResult>(result);
            var objectResult = (OkObjectResult)result;
            Assert.Equal(200, objectResult.StatusCode);

            var model = objectResult.Value as AnswerViewModel;

            if (model == null)
            {
                Assert.Fail("Null value");
                return;
            }

            Assert.Equal(expecteds, model);
        }

        [Fact]
        public async Task Answer_GetById_ReturnsNotFoundResult()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((AnswerViewModel)null!);

            // Act
            var result = await _controller.GetById(id);

            // Assert
            Assert.NotNull(result);

            Assert.IsType<NotFoundResult>(result);
            var notFoundResult = (NotFoundResult)result;
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task Answer_GetById_ReturnsInternalServerErrorResult()
        {
            // Arrange
            var id = Guid.NewGuid();

            _mockService.Setup(service => service.GetByIdAsync(id)).Throws(new Exception("Simulated exception"));

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
