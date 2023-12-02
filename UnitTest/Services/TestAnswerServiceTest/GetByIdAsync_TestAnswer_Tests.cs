using API.Data.DTOs.TestAnswer;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.TestAnswerServiceTest
{
    public class GetByIdAsync_TestAnswer_Tests
    {
        private readonly Mock<ITestAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITestAnswerService _service;

        public GetByIdAsync_TestAnswer_Tests()
        {
            _mockRepository = new Mock<ITestAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TestAnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new TestAnswer();
            var model = new TestAnswerViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<TestAnswerViewModel>(It.IsAny<TestAnswer>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<TestAnswerViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((TestAnswer)null!);

            _mockMapper.Setup(service => service.Map<TestAnswerViewModel>(It.IsAny<TestAnswer>()))
                       .Returns((TestAnswerViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
