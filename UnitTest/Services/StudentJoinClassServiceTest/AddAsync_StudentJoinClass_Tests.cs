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
    public class AddAsync_StudentJoinClass_Tests
    {
        private readonly Mock<IStudentJoinClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinClassService _service;

        public AddAsync_StudentJoinClass_Tests()
        {
            _mockRepository = new Mock<IStudentJoinClassRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinClassService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new StudentJoinClassAddModel { };

            var entity = new StudentJoinClass { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<StudentJoinClass>())).ReturnsAsync(new StudentJoinClass { StudentJoinClassId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<StudentJoinClass>(It.IsAny<StudentJoinClassAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<StudentJoinClassViewModel>(It.IsAny<StudentJoinClass>())).Returns(new StudentJoinClassViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<StudentJoinClassViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new StudentJoinClassAddModel { };

            var entity = new StudentJoinClass { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<StudentJoinClass>())).ReturnsAsync((StudentJoinClass)null!);
            _mockMapper.Setup(service => service.Map<StudentJoinClass>(It.IsAny<StudentJoinClassAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<StudentJoinClassViewModel>(It.IsAny<StudentJoinClass>())).Returns((StudentJoinClassViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
