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
    public class UpdateAsync_Course_Tests
    {
        private readonly Mock<ICourseRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseService _service;

        public UpdateAsync_Course_Tests()
        {
            _mockRepository = new Mock<ICourseRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new CourseEditModel { CourseId = id };
            var entity = new Course { CourseId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Course>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Course>(It.IsAny<CourseEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<CourseViewModel>(It.IsAny<Course>())).Returns(new CourseViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CourseViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new CourseEditModel { CourseId = id };
            var entity = new Course { CourseId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Course)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Course>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Course>(It.IsAny<CourseEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<CourseViewModel>(It.IsAny<Course>())).Returns((CourseViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
