using API.Data.DTOs.Notification;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.NotificationServiceTest
{
    public class AddAsync_Notification_Tests
    {
        private readonly Mock<INotificationRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly INotificationService _service;

        public AddAsync_Notification_Tests()
        {
            _mockRepository = new Mock<INotificationRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new NotificationService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new NotificationAddModel { };

            var entity = new Notification { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Notification>())).ReturnsAsync(new Notification { NotificationId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<Notification>(It.IsAny<NotificationAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<NotificationViewModel>(It.IsAny<Notification>())).Returns(new NotificationViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotificationViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new NotificationAddModel { };

            var entity = new Notification { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Notification>())).ReturnsAsync((Notification)null!);
            _mockMapper.Setup(service => service.Map<Notification>(It.IsAny<NotificationAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<NotificationViewModel>(It.IsAny<Notification>())).Returns((NotificationViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
