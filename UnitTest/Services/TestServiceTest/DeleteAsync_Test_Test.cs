using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.TestRepositoryTest
{
    public class DeleteAsync_Test_Tests
    {
        private readonly Mock<ITestRepository> _mockRepository;
        private readonly Mock<ITestAnswerRepository> _mockTestAnswerRepository;
        private readonly Mock<IStudentJoinClassRepository> _mockStudentJoinClassRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ITestService _service;

        public DeleteAsync_Test_Tests()
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
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Test());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Test>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Test)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Test>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
