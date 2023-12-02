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
    public class UpdateAsync_Topic_Tests
    {
        private readonly Mock<ITopicRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITopicService _service;

        public UpdateAsync_Topic_Tests()
        {
            _mockRepository = new Mock<ITopicRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TopicService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new TopicEditModel { TopicId = id };
            var entity = new Topic { TopicId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Topic>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Topic>(It.IsAny<TopicEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TopicViewModel>(It.IsAny<Topic>())).Returns(new TopicViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TopicViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new TopicEditModel { TopicId = id };
            var entity = new Topic { TopicId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Topic)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Topic>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Topic>(It.IsAny<TopicEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TopicViewModel>(It.IsAny<Topic>())).Returns((TopicViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
