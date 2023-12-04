using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.TopicRepositoryTest
{
    public class DeleteAsync_Topic_Tests
    {
        private readonly Mock<ITopicRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITopicService _service;

        public DeleteAsync_Topic_Tests()
        {
            _mockRepository = new Mock<ITopicRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TopicService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Topic());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Topic>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Topic)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Topic>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
