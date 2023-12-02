using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.CourseRepositoryTest
{
    public class DeleteAsync_Course_Tests
    {
        private readonly Mock<ICourseRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseService _service;

        public DeleteAsync_Course_Tests()
        {
            _mockRepository = new Mock<ICourseRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new Course());
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Course>())).ReturnsAsync(true);

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

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Course)null!);
            _mockRepository.Setup(x => x.RemoveAsync(It.IsAny<Course>())).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteAsync(id);

            // Assert
            Assert.False(result);
        }
    }
}
