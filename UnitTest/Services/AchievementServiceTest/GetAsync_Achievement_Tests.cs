using API.Commons.Paginations;
using API.Data.DTOs.Achievement;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.AchievementServiceTest
{
    public class GetAsync_Achievement_Tests
    {
        private readonly Mock<IAchievementRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAchievementService _service;

        public GetAsync_Achievement_Tests()
        {
            _mockRepository = new Mock<IAchievementRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AchievementService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new AchievementFilterModel();
            var entities = new List<Achievement> { new Achievement (), new Achievement () };
            var models = new List<AchievementViewModel> { new AchievementViewModel(), new AchievementViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Achievement, bool>>>(),
                    It.IsAny<Func<IQueryable<Achievement>, IOrderedQueryable<Achievement>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<AchievementViewModel>>(It.IsAny<IEnumerable<Achievement>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<AchievementViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new AchievementFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Achievement, bool>>>(),
                    It.IsAny<Func<IQueryable<Achievement>, IOrderedQueryable<Achievement>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<Achievement>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<AchievementViewModel>>(It.IsAny<IEnumerable<Achievement>>()))
                       .Returns((IEnumerable<AchievementViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
