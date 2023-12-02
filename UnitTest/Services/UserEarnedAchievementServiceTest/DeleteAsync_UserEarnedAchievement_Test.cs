using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.UserEarnedAchievementRepositoryTest
{
    public class DeleteAsync_UserEarnedAchievement_Tests
    {
        private readonly Mock<IUserEarnedAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IUserEarnedAchievementService _service;

        public DeleteAsync_UserEarnedAchievement_Tests()
        {
            _mockRepository = new Mock<IUserEarnedAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new UserEarnedAchievementService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new UserEarnedAchievement());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<UserEarnedAchievement>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((UserEarnedAchievement)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<UserEarnedAchievement>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
