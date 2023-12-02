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
    public class UpdateAsync_Notification_Tests
    {
        private readonly Mock<INotificationRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly INotificationService _service;

        public UpdateAsync_Notification_Tests()
        {
            _mockRepository = new Mock<INotificationRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new NotificationService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new NotificationEditModel { NotificationId = id };
            var entity = new Notification { NotificationId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Notification>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Notification>(It.IsAny<NotificationEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<NotificationViewModel>(It.IsAny<Notification>())).Returns(new NotificationViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<NotificationViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new NotificationEditModel { NotificationId = id };
            var entity = new Notification { NotificationId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Notification)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Notification>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Notification>(It.IsAny<NotificationEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<NotificationViewModel>(It.IsAny<Notification>())).Returns((NotificationViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
