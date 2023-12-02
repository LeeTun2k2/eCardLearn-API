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
    public class AddAsync_Achievement_Tests
    {
        private readonly Mock<IAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAchievementService _service;

        public AddAsync_Achievement_Tests()
        {
            _mockRepository = new Mock<IAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AchievementService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new AchievementAddModel { };

            var entity = new Achievement { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Achievement>())).ReturnsAsync(new Achievement { AchievementId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<Achievement>(It.IsAny<AchievementAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<AchievementViewModel>(It.IsAny<Achievement>())).Returns(new AchievementViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AchievementViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new AchievementAddModel { };

            var entity = new Achievement { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Achievement>())).ReturnsAsync((Achievement)null!);
            _mockMapper.Setup(service => service.Map<Achievement>(It.IsAny<AchievementAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<AchievementViewModel>(It.IsAny<Achievement>())).Returns((AchievementViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
