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
    public class UpdateAsync_CourseInClass_Tests
    {
        private readonly Mock<ICourseInClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseInClassService _service;

        public UpdateAsync_CourseInClass_Tests()
        {
            _mockRepository = new Mock<ICourseInClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseInClassService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new CourseInClassEditModel { CourseInClassId = id };
            var entity = new CourseInClass { CourseInClassId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<CourseInClass>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<CourseInClass>(It.IsAny<CourseInClassEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<CourseInClassViewModel>(It.IsAny<CourseInClass>())).Returns(new CourseInClassViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<CourseInClassViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new CourseInClassEditModel { CourseInClassId = id };
            var entity = new CourseInClass { CourseInClassId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((CourseInClass)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<CourseInClass>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<CourseInClass>(It.IsAny<CourseInClassEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<CourseInClassViewModel>(It.IsAny<CourseInClass>())).Returns((CourseInClassViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
