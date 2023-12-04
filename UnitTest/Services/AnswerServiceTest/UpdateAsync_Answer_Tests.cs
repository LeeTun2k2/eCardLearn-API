using API.Data.DTOs.Answer;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.AnswerServiceTest
{
    public class UpdateAsync_Answer_Tests
    {
        private readonly Mock<IAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAnswerService _service;

        public UpdateAsync_Answer_Tests()
        {
            _mockRepository = new Mock<IAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new AnswerEditModel { AnswerId = id };
            var entity = new Answer { AnswerId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Answer>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Answer>(It.IsAny<AnswerEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<AnswerViewModel>(It.IsAny<Answer>())).Returns(new AnswerViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AnswerViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new AnswerEditModel { AnswerId = id };
            var entity = new Answer { AnswerId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Answer)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Answer>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Answer>(It.IsAny<AnswerEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<AnswerViewModel>(It.IsAny<Answer>())).Returns((AnswerViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
