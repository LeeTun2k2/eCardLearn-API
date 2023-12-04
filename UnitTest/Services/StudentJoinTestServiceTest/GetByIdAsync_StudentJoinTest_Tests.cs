using API.Data.DTOs.StudentJoinTest;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.StudentJoinTestServiceTest
{
    public class GetByIdAsync_StudentJoinTest_Tests
    {
        private readonly Mock<IStudentJoinTestRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinTestService _service;

        public GetByIdAsync_StudentJoinTest_Tests()
        {
            _mockRepository = new Mock<IStudentJoinTestRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinTestService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new StudentJoinTest();
            var model = new StudentJoinTestViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<StudentJoinTestViewModel>(It.IsAny<StudentJoinTest>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<StudentJoinTestViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((StudentJoinTest)null!);

            _mockMapper.Setup(service => service.Map<StudentJoinTestViewModel>(It.IsAny<StudentJoinTest>()))
                       .Returns((StudentJoinTestViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
