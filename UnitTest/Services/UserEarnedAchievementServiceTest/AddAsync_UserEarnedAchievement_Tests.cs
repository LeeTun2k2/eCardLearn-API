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
    public class AddAsync_UserEarnedAchievement_Tests
    {
        private readonly Mock<IUserEarnedAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IUserEarnedAchievementService _service;

        public AddAsync_UserEarnedAchievement_Tests()
        {
            _mockRepository = new Mock<IUserEarnedAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new UserEarnedAchievementService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new UserEarnedAchievementAddModel { };

            var entity = new UserEarnedAchievement { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<UserEarnedAchievement>())).ReturnsAsync(new UserEarnedAchievement { UserEarnedAchievementId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<UserEarnedAchievement>(It.IsAny<UserEarnedAchievementAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<UserEarnedAchievementViewModel>(It.IsAny<UserEarnedAchievement>())).Returns(new UserEarnedAchievementViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<UserEarnedAchievementViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new UserEarnedAchievementAddModel { };

            var entity = new UserEarnedAchievement { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<UserEarnedAchievement>())).ReturnsAsync((UserEarnedAchievement)null!);
            _mockMapper.Setup(service => service.Map<UserEarnedAchievement>(It.IsAny<UserEarnedAchievementAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<UserEarnedAchievementViewModel>(It.IsAny<UserEarnedAchievement>())).Returns((UserEarnedAchievementViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
