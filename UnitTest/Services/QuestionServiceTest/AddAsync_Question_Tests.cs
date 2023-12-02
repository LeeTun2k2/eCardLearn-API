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
    public class AddAsync_Question_Tests
    {
        private readonly Mock<IQuestionRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IQuestionService _service;

        public AddAsync_Question_Tests()
        {
            _mockRepository = new Mock<IQuestionRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new QuestionService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new QuestionAddModel { };

            var entity = new Question { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Question>())).ReturnsAsync(new Question { QuestionId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<Question>(It.IsAny<QuestionAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<QuestionViewModel>(It.IsAny<Question>())).Returns(new QuestionViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<QuestionViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new QuestionAddModel { };

            var entity = new Question { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Question>())).ReturnsAsync((Question)null!);
            _mockMapper.Setup(service => service.Map<Question>(It.IsAny<QuestionAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<QuestionViewModel>(It.IsAny<Question>())).Returns((QuestionViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
