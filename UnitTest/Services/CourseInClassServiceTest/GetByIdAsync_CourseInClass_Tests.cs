using API.Data.DTOs.CourseInClass;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.CourseInClassServiceTest
{
    public class GetByIdAsync_CourseInClass_Tests
    {
        private readonly Mock<ICourseInClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseInClassService _service;

        public GetByIdAsync_CourseInClass_Tests()
        {
            _mockRepository = new Mock<ICourseInClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseInClassService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new CourseInClass();
            var model = new CourseInClassViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<CourseInClassViewModel>(It.IsAny<CourseInClass>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<CourseInClassViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((CourseInClass)null!);

            _mockMapper.Setup(service => service.Map<CourseInClassViewModel>(It.IsAny<CourseInClass>()))
                       .Returns((CourseInClassViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
