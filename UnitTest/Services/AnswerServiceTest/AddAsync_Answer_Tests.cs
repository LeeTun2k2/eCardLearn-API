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
    public class AddAsync_Answer_Tests
    {
        private readonly Mock<IAnswerRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IAnswerService _service;

        public AddAsync_Answer_Tests()
        {
            _mockRepository = new Mock<IAnswerRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new AnswerService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new AnswerAddModel { };

            var entity = new Answer { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Answer>())).ReturnsAsync(new Answer { AnswerId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<Answer>(It.IsAny<AnswerAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<AnswerViewModel>(It.IsAny<Answer>())).Returns(new AnswerViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AnswerViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new AnswerAddModel { };

            var entity = new Answer { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Answer>())).ReturnsAsync((Answer)null!);
            _mockMapper.Setup(service => service.Map<Answer>(It.IsAny<AnswerAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<AnswerViewModel>(It.IsAny<Answer>())).Returns((AnswerViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
