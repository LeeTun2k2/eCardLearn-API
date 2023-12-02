using API.Data.DTOs.Test;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.TestServiceTest
{
    public class AddAsync_Test_Tests
    {
        private readonly Mock<ITestRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITestService _service;

        public AddAsync_Test_Tests()
        {
            _mockRepository = new Mock<ITestRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new TestService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new TestAddModel { };

            var entity = new Test { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Test>())).ReturnsAsync(new Test { TestId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<Test>(It.IsAny<TestAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TestViewModel>(It.IsAny<Test>())).Returns(new TestViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TestViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new TestAddModel { };

            var entity = new Test { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Test>())).ReturnsAsync((Test)null!);
            _mockMapper.Setup(service => service.Map<Test>(It.IsAny<TestAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TestViewModel>(It.IsAny<Test>())).Returns((TestViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
