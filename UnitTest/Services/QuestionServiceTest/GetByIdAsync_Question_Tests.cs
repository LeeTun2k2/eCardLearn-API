using API.Data.DTOs.Question;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.QuestionServiceTest
{
    public class GetByIdAsync_Question_Tests
    {
        private readonly Mock<IQuestionRepository> _mockRepository;
        private readonly Mock<IOpenTriviaDBCategoryRepository> _mockOpenTriviaDBRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IQuestionService _service;

        public GetByIdAsync_Question_Tests()
        {
            _mockRepository = new Mock<IQuestionRepository>();
            _mockOpenTriviaDBRepository = new Mock<IOpenTriviaDBCategoryRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new QuestionService(_mockRepository.Object, _mockOpenTriviaDBRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new Question();
            var model = new QuestionViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<QuestionViewModel>(It.IsAny<Question>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<QuestionViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((Question)null!);

            _mockMapper.Setup(service => service.Map<QuestionViewModel>(It.IsAny<Question>()))
                       .Returns((QuestionViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
