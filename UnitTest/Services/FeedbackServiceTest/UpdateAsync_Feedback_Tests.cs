using API.Data.DTOs.Feedback;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.FeedbackServiceTest
{
    public class UpdateAsync_Feedback_Tests
    {
        private readonly Mock<IFeedbackRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IFeedbackService _service;

        public UpdateAsync_Feedback_Tests()
        {
            _mockRepository = new Mock<IFeedbackRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new FeedbackService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new FeedbackEditModel { FeedbackId = id };
            var entity = new Feedback { FeedbackId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Feedback>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Feedback>(It.IsAny<FeedbackEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<FeedbackViewModel>(It.IsAny<Feedback>())).Returns(new FeedbackViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<FeedbackViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new FeedbackEditModel { FeedbackId = id };
            var entity = new Feedback { FeedbackId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Feedback)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Feedback>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Feedback>(It.IsAny<FeedbackEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<FeedbackViewModel>(It.IsAny<Feedback>())).Returns((FeedbackViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
