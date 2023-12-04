using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.StudentJoinClassRepositoryTest
{
    public class DeleteAsync_StudentJoinClass_Tests
    {
        private readonly Mock<IStudentJoinClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinClassService _service;

        public DeleteAsync_StudentJoinClass_Tests()
        {
            _mockRepository = new Mock<IStudentJoinClassRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinClassService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new StudentJoinClass());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<StudentJoinClass>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((StudentJoinClass)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<StudentJoinClass>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
