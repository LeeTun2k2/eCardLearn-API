using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.NotificationRepositoryTest
{
    public class DeleteAsync_Notification_Tests
    {
        private readonly Mock<INotificationRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly INotificationService _service;

        public DeleteAsync_Notification_Tests()
        {
            _mockRepository = new Mock<INotificationRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new NotificationService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Notification());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Notification>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Notification)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Notification>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
