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
    public class GetByIdAsync_UserEarnedAchievement_Tests
    {
        private readonly Mock<IUserEarnedAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IUserEarnedAchievementService _service;

        public GetByIdAsync_UserEarnedAchievement_Tests()
        {
            _mockRepository = new Mock<IUserEarnedAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new UserEarnedAchievementService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new UserEarnedAchievement();
            var model = new UserEarnedAchievementViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<UserEarnedAchievementViewModel>(It.IsAny<UserEarnedAchievement>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<UserEarnedAchievementViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((UserEarnedAchievement)null!);

            _mockMapper.Setup(service => service.Map<UserEarnedAchievementViewModel>(It.IsAny<UserEarnedAchievement>()))
                       .Returns((UserEarnedAchievementViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
