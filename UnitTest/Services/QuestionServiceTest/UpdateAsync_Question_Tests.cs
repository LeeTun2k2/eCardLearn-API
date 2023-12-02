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
    public class UpdateAsync_Question_Tests
    {
        private readonly Mock<IQuestionRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IQuestionService _service;

        public UpdateAsync_Question_Tests()
        {
            _mockRepository = new Mock<IQuestionRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new QuestionService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new QuestionEditModel { QuestionId = id };
            var entity = new Question { QuestionId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Question>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Question>(It.IsAny<QuestionEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<QuestionViewModel>(It.IsAny<Question>())).Returns(new QuestionViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<QuestionViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new QuestionEditModel { QuestionId = id };
            var entity = new Question { QuestionId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Question)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Question>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Question>(It.IsAny<QuestionEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<QuestionViewModel>(It.IsAny<Question>())).Returns((QuestionViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
