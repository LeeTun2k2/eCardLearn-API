using API.Commons.Paginations;
using API.Data.DTOs.Notification;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.NotificationServiceTest
{
    public class GetAsync_Notification_Tests
    {
        private readonly Mock<INotificationRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly INotificationService _service;

        public GetAsync_Notification_Tests()
        {
            _mockRepository = new Mock<INotificationRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new NotificationService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new NotificationFilterModel();
            var entities = new List<Notification> { new Notification (), new Notification () };
            var models = new List<NotificationViewModel> { new NotificationViewModel(), new NotificationViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Notification, bool>>>(),
                    It.IsAny<Func<IQueryable<Notification>, IOrderedQueryable<Notification>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<NotificationViewModel>>(It.IsAny<IEnumerable<Notification>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<NotificationViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new NotificationFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Notification, bool>>>(),
                    It.IsAny<Func<IQueryable<Notification>, IOrderedQueryable<Notification>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<Notification>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<NotificationViewModel>>(It.IsAny<IEnumerable<Notification>>()))
                       .Returns((IEnumerable<NotificationViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
