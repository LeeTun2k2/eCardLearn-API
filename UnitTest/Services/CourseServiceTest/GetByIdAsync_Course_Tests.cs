using API.Data.DTOs.Course;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.CourseServiceTest
{
    public class GetByIdAsync_Course_Tests
    {
        private readonly Mock<ICourseRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseService _service;

        public GetByIdAsync_Course_Tests()
        {
            _mockRepository = new Mock<ICourseRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new Course();
            var model = new CourseViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<CourseViewModel>(It.IsAny<Course>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<CourseViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((Course)null!);

            _mockMapper.Setup(service => service.Map<CourseViewModel>(It.IsAny<Course>()))
                       .Returns((CourseViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
