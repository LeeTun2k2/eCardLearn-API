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
    public class GetByIdAsync_Answer_Tests
    {
        private readonly Mock<IAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAnswerService _service;

        public GetByIdAsync_Answer_Tests()
        {
            _mockRepository = new Mock<IAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new Answer();
            var model = new AnswerViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<AnswerViewModel>(It.IsAny<Answer>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<AnswerViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((Answer)null!);

            _mockMapper.Setup(service => service.Map<AnswerViewModel>(It.IsAny<Answer>()))
                       .Returns((AnswerViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
