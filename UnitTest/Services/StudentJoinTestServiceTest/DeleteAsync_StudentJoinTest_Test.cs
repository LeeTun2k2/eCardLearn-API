using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.StudentJoinTestRepositoryTest
{
    public class DeleteAsync_StudentJoinTest_Tests
    {
        private readonly Mock<IStudentJoinTestRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinTestService _service;

        public DeleteAsync_StudentJoinTest_Tests()
        {
            _mockRepository = new Mock<IStudentJoinTestRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinTestService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new StudentJoinTest());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<StudentJoinTest>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((StudentJoinTest)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<StudentJoinTest>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
