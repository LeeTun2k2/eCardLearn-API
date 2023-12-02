using API.Data.DTOs.Achievement;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.AchievementServiceTest
{
    public class GetByIdAsync_Achievement_Tests
    {
        private readonly Mock<IAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAchievementService _service;

        public GetByIdAsync_Achievement_Tests()
        {
            _mockRepository = new Mock<IAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AchievementService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new Achievement();
            var model = new AchievementViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<AchievementViewModel>(It.IsAny<Achievement>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<AchievementViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((Achievement)null!);

            _mockMapper.Setup(service => service.Map<AchievementViewModel>(It.IsAny<Achievement>()))
                       .Returns((AchievementViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
