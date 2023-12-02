using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.TestAnswerRepositoryTest
{
    public class DeleteAsync_TestAnswer_Tests
    {
        private readonly Mock<ITestAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITestAnswerService _service;

        public DeleteAsync_TestAnswer_Tests()
        {
            _mockRepository = new Mock<ITestAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TestAnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new TestAnswer());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<TestAnswer>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((TestAnswer)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<TestAnswer>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
