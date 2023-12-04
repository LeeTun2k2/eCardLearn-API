using API.Commons.Paginations;
using API.Data.DTOs.Topic;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.TopicServiceTest
{
    public class GetAsync_Topic_Tests
    {
        private readonly Mock<ITopicRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITopicService _service;

        public GetAsync_Topic_Tests()
        {
            _mockRepository = new Mock<ITopicRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TopicService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new TopicFilterModel();
            var entities = new List<Topic> { new Topic (), new Topic () };
            var models = new List<TopicViewModel> { new TopicViewModel(), new TopicViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Topic, bool>>>(),
                    It.IsAny<Func<IQueryable<Topic>, IOrderedQueryable<Topic>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<TopicViewModel>>(It.IsAny<IEnumerable<Topic>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<TopicViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new TopicFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Topic, bool>>>(),
                    It.IsAny<Func<IQueryable<Topic>, IOrderedQueryable<Topic>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<Topic>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<TopicViewModel>>(It.IsAny<IEnumerable<Topic>>()))
                       .Returns((IEnumerable<TopicViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
