using API.Data.DTOs.StudentJoinClass;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.StudentJoinClassServiceTest
{
    public class GetByIdAsync_StudentJoinClass_Tests
    {
        private readonly Mock<IStudentJoinClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinClassService _service;

        public GetByIdAsync_StudentJoinClass_Tests()
        {
            _mockRepository = new Mock<IStudentJoinClassRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinClassService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new StudentJoinClass();
            var model = new StudentJoinClassViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<StudentJoinClassViewModel>(It.IsAny<StudentJoinClass>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<StudentJoinClassViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((StudentJoinClass)null!);

            _mockMapper.Setup(service => service.Map<StudentJoinClassViewModel>(It.IsAny<StudentJoinClass>()))
                       .Returns((StudentJoinClassViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
