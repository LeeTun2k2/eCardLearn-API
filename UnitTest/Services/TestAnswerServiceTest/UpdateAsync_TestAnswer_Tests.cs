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
    public class UpdateAsync_TestAnswer_Tests
    {
        private readonly Mock<ITestAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITestAnswerService _service;

        public UpdateAsync_TestAnswer_Tests()
        {
            _mockRepository = new Mock<ITestAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TestAnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new TestAnswerEditModel { TestAnswerId = id };
            var entity = new TestAnswer { TestAnswerId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<TestAnswer>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<TestAnswer>(It.IsAny<TestAnswerEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TestAnswerViewModel>(It.IsAny<TestAnswer>())).Returns(new TestAnswerViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TestAnswerViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new TestAnswerEditModel { TestAnswerId = id };
            var entity = new TestAnswer { TestAnswerId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((TestAnswer)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<TestAnswer>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<TestAnswer>(It.IsAny<TestAnswerEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TestAnswerViewModel>(It.IsAny<TestAnswer>())).Returns((TestAnswerViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
