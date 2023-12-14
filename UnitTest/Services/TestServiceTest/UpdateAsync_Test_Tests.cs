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
    public class UpdateAsync_Test_Tests
    {
        private readonly Mock<ITestRepository> _mockRepository;
        private readonly Mock<ITestAnswerRepository> _mockTestAnswerRepository;
        private readonly Mock<IStudentJoinClassRepository> _mockStudentJoinClassRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITestService _service;

        public UpdateAsync_Test_Tests()
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
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new TestEditModel { TestId = id };
            var entity = new Test { TestId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Test>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Test>(It.IsAny<TestEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TestViewModel>(It.IsAny<Test>())).Returns(new TestViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TestViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new TestEditModel { TestId = id };
            var entity = new Test { TestId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Test)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Test>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Test>(It.IsAny<TestEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<TestViewModel>(It.IsAny<Test>())).Returns((TestViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
