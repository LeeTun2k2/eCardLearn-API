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
    public class GetByIdAsync_Notification_Tests
    {
        private readonly Mock<INotificationRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly INotificationService _service;

        public GetByIdAsync_Notification_Tests()
        {
            _mockRepository = new Mock<INotificationRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new NotificationService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new Notification();
            var model = new NotificationViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<NotificationViewModel>(It.IsAny<Notification>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<NotificationViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((Notification)null!);

            _mockMapper.Setup(service => service.Map<NotificationViewModel>(It.IsAny<Notification>()))
                       .Returns((NotificationViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
