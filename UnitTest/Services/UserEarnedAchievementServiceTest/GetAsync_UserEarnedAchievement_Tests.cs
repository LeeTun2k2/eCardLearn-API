using API.Commons.Paginations;
using API.Data.DTOs.UserEarnedAchievement;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.UserEarnedAchievementServiceTest
{
    public class GetAsync_UserEarnedAchievement_Tests
    {
        private readonly Mock<IUserEarnedAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IUserEarnedAchievementService _service;

        public GetAsync_UserEarnedAchievement_Tests()
        {
            _mockRepository = new Mock<IUserEarnedAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new UserEarnedAchievementService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new UserEarnedAchievementFilterModel();
            var entities = new List<UserEarnedAchievement> { new UserEarnedAchievement (), new UserEarnedAchievement () };
            var models = new List<UserEarnedAchievementViewModel> { new UserEarnedAchievementViewModel(), new UserEarnedAchievementViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<UserEarnedAchievement, bool>>>(),
                    It.IsAny<Func<IQueryable<UserEarnedAchievement>, IOrderedQueryable<UserEarnedAchievement>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<UserEarnedAchievementViewModel>>(It.IsAny<IEnumerable<UserEarnedAchievement>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<UserEarnedAchievementViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new UserEarnedAchievementFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<UserEarnedAchievement, bool>>>(),
                    It.IsAny<Func<IQueryable<UserEarnedAchievement>, IOrderedQueryable<UserEarnedAchievement>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<UserEarnedAchievement>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<UserEarnedAchievementViewModel>>(It.IsAny<IEnumerable<UserEarnedAchievement>>()))
                       .Returns((IEnumerable<UserEarnedAchievementViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
