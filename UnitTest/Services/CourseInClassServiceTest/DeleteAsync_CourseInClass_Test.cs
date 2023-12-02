using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.CourseInClassRepositoryTest
{
    public class DeleteAsync_CourseInClass_Tests
    {
        private readonly Mock<ICourseInClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseInClassService _service;

        public DeleteAsync_CourseInClass_Tests()
        {
            _mockRepository = new Mock<ICourseInClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseInClassService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new CourseInClass());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<CourseInClass>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((CourseInClass)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<CourseInClass>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
