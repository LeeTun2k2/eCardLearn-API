using API.Data.DTOs.Test;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.TestServiceTest
{
    public class GetByIdAsync_Test_Tests
    {
        private readonly Mock<ITestRepository> _mockRepository;
        private readonly Mock<ITestAnswerRepository> _mockTestAnswerRepository;
        private readonly Mock<IStudentJoinClassRepository> _mockStudentJoinClassRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITestService _service;

        public GetByIdAsync_Test_Tests()
        {
            _mockRepository = new Mock<ITestRepository>();
            _mockTestAnswerRepository = new Mock<ITestAnswerRepository>();
            _mockStudentJoinClassRepository = new Mock<IStudentJoinClassRepository> { };
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            var controllerContext = new ControllerContext
            {
                HttpContext = MockHttpContext.CreateMockHttpContext(() => "00000000-0000-0000-0000-000000000001")
            };
            _service = new TestService(
                _mockRepository.Object,
                _mockTestAnswerRepository.Object,
                _mockStudentJoinClassRepository.Object,
                userManager,
                _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new Test();
            var model = new TestViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<TestViewModel>(It.IsAny<Test>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<TestViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((Test)null!);

            _mockMapper.Setup(service => service.Map<TestViewModel>(It.IsAny<Test>()))
                       .Returns((TestViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
