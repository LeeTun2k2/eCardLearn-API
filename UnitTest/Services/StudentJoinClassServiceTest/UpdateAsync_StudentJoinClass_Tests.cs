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
    public class UpdateAsync_StudentJoinClass_Tests
    {
        private readonly Mock<IStudentJoinClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinClassService _service;

        public UpdateAsync_StudentJoinClass_Tests()
        {
            _mockRepository = new Mock<IStudentJoinClassRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinClassService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new StudentJoinClassEditModel { StudentJoinClassId = id };
            var entity = new StudentJoinClass { StudentJoinClassId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<StudentJoinClass>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<StudentJoinClass>(It.IsAny<StudentJoinClassEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<StudentJoinClassViewModel>(It.IsAny<StudentJoinClass>())).Returns(new StudentJoinClassViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<StudentJoinClassViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new StudentJoinClassEditModel { StudentJoinClassId = id };
            var entity = new StudentJoinClass { StudentJoinClassId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((StudentJoinClass)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<StudentJoinClass>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<StudentJoinClass>(It.IsAny<StudentJoinClassEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<StudentJoinClassViewModel>(It.IsAny<StudentJoinClass>())).Returns((StudentJoinClassViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
