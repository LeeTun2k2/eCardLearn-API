using API.Commons.Paginations;
using API.Data.DTOs.Question;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.QuestionServiceTest
{
    public class GetAsync_Question_Tests
    {
        private readonly Mock<IQuestionRepository> _mockRepository;
        private readonly Mock<IOpenTriviaDBCategoryRepository> _mockOpenTriviaDBRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IQuestionService _service;

        public GetAsync_Question_Tests()
        {
            _mockRepository = new Mock<IQuestionRepository>();
            _mockOpenTriviaDBRepository = new Mock<IOpenTriviaDBCategoryRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new QuestionService(_mockRepository.Object, _mockOpenTriviaDBRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new QuestionFilterModel();
            var entities = new List<Question> { new Question (), new Question () };
            var models = new List<QuestionViewModel> { new QuestionViewModel(), new QuestionViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Question, bool>>>(),
                    It.IsAny<Func<IQueryable<Question>, IOrderedQueryable<Question>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<QuestionViewModel>>(It.IsAny<IEnumerable<Question>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<QuestionViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new QuestionFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Question, bool>>>(),
                    It.IsAny<Func<IQueryable<Question>, IOrderedQueryable<Question>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<Question>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<QuestionViewModel>>(It.IsAny<IEnumerable<Question>>()))
                       .Returns((IEnumerable<QuestionViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
