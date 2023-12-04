using API.Data.DTOs.UserEarnedAchievement;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.UserEarnedAchievementServiceTest
{
    public class UpdateAsync_UserEarnedAchievement_Tests
    {
        private readonly Mock<IUserEarnedAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IUserEarnedAchievementService _service;

        public UpdateAsync_UserEarnedAchievement_Tests()
        {
            _mockRepository = new Mock<IUserEarnedAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new UserEarnedAchievementService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new UserEarnedAchievementEditModel { UserEarnedAchievementId = id };
            var entity = new UserEarnedAchievement { UserEarnedAchievementId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<UserEarnedAchievement>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<UserEarnedAchievement>(It.IsAny<UserEarnedAchievementEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<UserEarnedAchievementViewModel>(It.IsAny<UserEarnedAchievement>())).Returns(new UserEarnedAchievementViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserEarnedAchievementViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new UserEarnedAchievementEditModel { UserEarnedAchievementId = id };
            var entity = new UserEarnedAchievement { UserEarnedAchievementId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((UserEarnedAchievement)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<UserEarnedAchievement>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<UserEarnedAchievement>(It.IsAny<UserEarnedAchievementEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<UserEarnedAchievementViewModel>(It.IsAny<UserEarnedAchievement>())).Returns((UserEarnedAchievementViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
