using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.AnswerRepositoryTest
{
    public class DeleteAsync_Answer_Tests
    {
        private readonly Mock<IAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAnswerService _service;

        public DeleteAsync_Answer_Tests()
        {
            _mockRepository = new Mock<IAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Answer());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Answer>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Answer)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Answer>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
