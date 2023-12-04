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
    public class AddAsync_Feedback_Tests
    {
        private readonly Mock<IFeedbackRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IFeedbackService _service;

        public AddAsync_Feedback_Tests()
        {
            _mockRepository = new Mock<IFeedbackRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new FeedbackService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new FeedbackAddModel { };

            var entity = new Feedback { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Feedback>())).ReturnsAsync(new Feedback { FeedbackId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<Feedback>(It.IsAny<FeedbackAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<FeedbackViewModel>(It.IsAny<Feedback>())).Returns(new FeedbackViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<FeedbackViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new FeedbackAddModel { };

            var entity = new Feedback { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Feedback>())).ReturnsAsync((Feedback)null!);
            _mockMapper.Setup(service => service.Map<Feedback>(It.IsAny<FeedbackAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<FeedbackViewModel>(It.IsAny<Feedback>())).Returns((FeedbackViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
