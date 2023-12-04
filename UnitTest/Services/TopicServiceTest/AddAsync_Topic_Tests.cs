using API.Data.DTOs.Topic;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.TopicServiceTest
{
    public class AddAsync_Topic_Tests
    {
        private readonly Mock<ITopicRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITopicService _service;

        public AddAsync_Topic_Tests()
        {
            _mockRepository = new Mock<ITopicRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TopicService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new TopicAddModel { };

            var entity = new Topic { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Topic>())).ReturnsAsync(new Topic { TopicId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<Topic>(It.IsAny<TopicAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TopicViewModel>(It.IsAny<Topic>())).Returns(new TopicViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TopicViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new TopicAddModel { };

            var entity = new Topic { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Topic>())).ReturnsAsync((Topic)null!);
            _mockMapper.Setup(service => service.Map<Topic>(It.IsAny<TopicAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TopicViewModel>(It.IsAny<Topic>())).Returns((TopicViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
