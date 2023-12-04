using API.Commons.Paginations;
using API.Data.DTOs.Answer;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.AnswerServiceTest
{
    public class GetAsync_Answer_Tests
    {
        private readonly Mock<IAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAnswerService _service;

        public GetAsync_Answer_Tests()
        {
            _mockRepository = new Mock<IAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new AnswerFilterModel();
            var entities = new List<Answer> { new Answer (), new Answer () };
            var models = new List<AnswerViewModel> { new AnswerViewModel(), new AnswerViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Answer, bool>>>(),
                    It.IsAny<Func<IQueryable<Answer>, IOrderedQueryable<Answer>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<AnswerViewModel>>(It.IsAny<IEnumerable<Answer>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<AnswerViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new AnswerFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Answer, bool>>>(),
                    It.IsAny<Func<IQueryable<Answer>, IOrderedQueryable<Answer>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<Answer>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<AnswerViewModel>>(It.IsAny<IEnumerable<Answer>>()))
                       .Returns((IEnumerable<AnswerViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
