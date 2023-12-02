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
    public class AddAsync_Course_Tests
    {
        private readonly Mock<ICourseRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseService _service;

        public AddAsync_Course_Tests()
        {
            _mockRepository = new Mock<ICourseRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new CourseAddModel { };

            var entity = new Course { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Course>())).ReturnsAsync(new Course { CourseId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<Course>(It.IsAny<CourseAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<CourseViewModel>(It.IsAny<Course>())).Returns(new CourseViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CourseViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new CourseAddModel { };

            var entity = new Course { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Course>())).ReturnsAsync((Course)null!);
            _mockMapper.Setup(service => service.Map<Course>(It.IsAny<CourseAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<CourseViewModel>(It.IsAny<Course>())).Returns((CourseViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
