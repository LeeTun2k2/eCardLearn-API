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
    public class AddAsync_StudentJoinTest_Tests
    {
        private readonly Mock<IStudentJoinTestRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinTestService _service;

        public AddAsync_StudentJoinTest_Tests()
        {
            _mockRepository = new Mock<IStudentJoinTestRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinTestService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new StudentJoinTestAddModel { };

            var entity = new StudentJoinTest { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<StudentJoinTest>())).ReturnsAsync(new StudentJoinTest { StudentJoinTestId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<StudentJoinTest>(It.IsAny<StudentJoinTestAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<StudentJoinTestViewModel>(It.IsAny<StudentJoinTest>())).Returns(new StudentJoinTestViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<StudentJoinTestViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new StudentJoinTestAddModel { };

            var entity = new StudentJoinTest { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<StudentJoinTest>())).ReturnsAsync((StudentJoinTest)null!);
            _mockMapper.Setup(service => service.Map<StudentJoinTest>(It.IsAny<StudentJoinTestAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<StudentJoinTestViewModel>(It.IsAny<StudentJoinTest>())).Returns((StudentJoinTestViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
