using API.Commons.Paginations;
using API.Data.DTOs.TestAnswer;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.TestAnswerServiceTest
{
    public class GetAsync_TestAnswer_Tests
    {
        private readonly Mock<ITestAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITestAnswerService _service;

        public GetAsync_TestAnswer_Tests()
        {
            _mockRepository = new Mock<ITestAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TestAnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new TestAnswerFilterModel();
            var entities = new List<TestAnswer> { new TestAnswer (), new TestAnswer () };
            var models = new List<TestAnswerViewModel> { new TestAnswerViewModel(), new TestAnswerViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<TestAnswer, bool>>>(),
                    It.IsAny<Func<IQueryable<TestAnswer>, IOrderedQueryable<TestAnswer>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<TestAnswerViewModel>>(It.IsAny<IEnumerable<TestAnswer>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<TestAnswerViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new TestAnswerFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<TestAnswer, bool>>>(),
                    It.IsAny<Func<IQueryable<TestAnswer>, IOrderedQueryable<TestAnswer>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<TestAnswer>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<TestAnswerViewModel>>(It.IsAny<IEnumerable<TestAnswer>>()))
                       .Returns((IEnumerable<TestAnswerViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
