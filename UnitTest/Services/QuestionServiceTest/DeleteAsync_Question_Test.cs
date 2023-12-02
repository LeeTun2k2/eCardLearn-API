using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.QuestionRepositoryTest
{
    public class DeleteAsync_Question_Tests
    {
        private readonly Mock<IQuestionRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IQuestionService _service;

        public DeleteAsync_Question_Tests()
        {
            _mockRepository = new Mock<IQuestionRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new QuestionService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Question());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Question>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Question)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Question>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
