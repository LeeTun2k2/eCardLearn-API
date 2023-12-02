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
    public class AddAsync_CourseInClass_Tests
    {
        private readonly Mock<ICourseInClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseInClassService _service;

        public AddAsync_CourseInClass_Tests()
        {
            _mockRepository = new Mock<ICourseInClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseInClassService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new CourseInClassAddModel { };

            var entity = new CourseInClass { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<CourseInClass>())).ReturnsAsync(new CourseInClass { CourseInClassId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<CourseInClass>(It.IsAny<CourseInClassAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<CourseInClassViewModel>(It.IsAny<CourseInClass>())).Returns(new CourseInClassViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CourseInClassViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new CourseInClassAddModel { };

            var entity = new CourseInClass { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<CourseInClass>())).ReturnsAsync((CourseInClass)null!);
            _mockMapper.Setup(service => service.Map<CourseInClass>(It.IsAny<CourseInClassAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<CourseInClassViewModel>(It.IsAny<CourseInClass>())).Returns((CourseInClassViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
