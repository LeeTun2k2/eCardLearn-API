using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.ClassRepositoryTest
{
    public class DeleteAsync_Class_Tests
    {
        private readonly Mock<IClassRepository> _mockRepository;
        private readonly Mock<ICourseInClassRepository> _mockCourseInClassRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IClassService _service;

        public DeleteAsync_Class_Tests()
        {
            _mockRepository = new Mock<IClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockCourseInClassRepository = new Mock<ICourseInClassRepository>();
            _service = new ClassService(_mockRepository.Object, _mockCourseInClassRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Class());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Class>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Class)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Class>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
