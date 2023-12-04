using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.AchievementRepositoryTest
{
    public class DeleteAsync_Achievement_Tests
    {
        private readonly Mock<IAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAchievementService _service;

        public DeleteAsync_Achievement_Tests()
        {
            _mockRepository = new Mock<IAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AchievementService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Achievement());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Achievement>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Achievement)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Achievement>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
