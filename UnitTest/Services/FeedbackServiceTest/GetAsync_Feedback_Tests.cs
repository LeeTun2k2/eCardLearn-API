using API.Commons.Paginations;
using API.Data.DTOs.Feedback;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.FeedbackServiceTest
{
    public class GetAsync_Feedback_Tests
    {
        private readonly Mock<IFeedbackRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IFeedbackService _service;

        public GetAsync_Feedback_Tests()
        {
            _mockRepository = new Mock<IFeedbackRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new FeedbackService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new FeedbackFilterModel();
            var entities = new List<Feedback> { new Feedback (), new Feedback () };
            var models = new List<FeedbackViewModel> { new FeedbackViewModel(), new FeedbackViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Feedback, bool>>>(),
                    It.IsAny<Func<IQueryable<Feedback>, IOrderedQueryable<Feedback>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<FeedbackViewModel>>(It.IsAny<IEnumerable<Feedback>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<FeedbackViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new FeedbackFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Feedback, bool>>>(),
                    It.IsAny<Func<IQueryable<Feedback>, IOrderedQueryable<Feedback>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<Feedback>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<FeedbackViewModel>>(It.IsAny<IEnumerable<Feedback>>()))
                       .Returns((IEnumerable<FeedbackViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
