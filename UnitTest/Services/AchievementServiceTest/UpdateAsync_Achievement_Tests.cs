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
    public class UpdateAsync_Achievement_Tests
    {
        private readonly Mock<IAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAchievementService _service;

        public UpdateAsync_Achievement_Tests()
        {
            _mockRepository = new Mock<IAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AchievementService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new AchievementEditModel { AchievementId = id };
            var entity = new Achievement { AchievementId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Achievement>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Achievement>(It.IsAny<AchievementEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<AchievementViewModel>(It.IsAny<Achievement>())).Returns(new AchievementViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AchievementViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new AchievementEditModel { AchievementId = id };
            var entity = new Achievement { AchievementId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Achievement)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Achievement>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Achievement>(It.IsAny<AchievementEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<AchievementViewModel>(It.IsAny<Achievement>())).Returns((AchievementViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
