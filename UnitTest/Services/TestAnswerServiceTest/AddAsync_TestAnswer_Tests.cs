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
    public class AddAsync_TestAnswer_Tests
    {
        private readonly Mock<ITestAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITestAnswerService _service;

        public AddAsync_TestAnswer_Tests()
        {
            _mockRepository = new Mock<ITestAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TestAnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new TestAnswerAddModel { };

            var entity = new TestAnswer { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<TestAnswer>())).ReturnsAsync(new TestAnswer { TestAnswerId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<TestAnswer>(It.IsAny<TestAnswerAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TestAnswerViewModel>(It.IsAny<TestAnswer>())).Returns(new TestAnswerViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TestAnswerViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new TestAnswerAddModel { };

            var entity = new TestAnswer { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<TestAnswer>())).ReturnsAsync((TestAnswer)null!);
            _mockMapper.Setup(service => service.Map<TestAnswer>(It.IsAny<TestAnswerAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TestAnswerViewModel>(It.IsAny<TestAnswer>())).Returns((TestAnswerViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
