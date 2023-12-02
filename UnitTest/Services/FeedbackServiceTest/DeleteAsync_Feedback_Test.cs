using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.FeedbackRepositoryTest
{
    public class DeleteAsync_Feedback_Tests
    {
        private readonly Mock<IFeedbackRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IFeedbackService _service;

        public DeleteAsync_Feedback_Tests()
        {
            _mockRepository = new Mock<IFeedbackRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new FeedbackService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Feedback());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Feedback>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Feedback)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Feedback>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
