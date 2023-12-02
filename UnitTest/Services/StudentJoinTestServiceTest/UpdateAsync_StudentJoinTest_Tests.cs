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
    public class UpdateAsync_StudentJoinTest_Tests
    {
        private readonly Mock<IStudentJoinTestRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinTestService _service;

        public UpdateAsync_StudentJoinTest_Tests()
        {
            _mockRepository = new Mock<IStudentJoinTestRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinTestService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new StudentJoinTestEditModel { StudentJoinTestId = id };
            var entity = new StudentJoinTest { StudentJoinTestId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<StudentJoinTest>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<StudentJoinTest>(It.IsAny<StudentJoinTestEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<StudentJoinTestViewModel>(It.IsAny<StudentJoinTest>())).Returns(new StudentJoinTestViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<StudentJoinTestViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new StudentJoinTestEditModel { StudentJoinTestId = id };
            var entity = new StudentJoinTest { StudentJoinTestId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((StudentJoinTest)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<StudentJoinTest>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<StudentJoinTest>(It.IsAny<StudentJoinTestEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<StudentJoinTestViewModel>(It.IsAny<StudentJoinTest>())).Returns((StudentJoinTestViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
