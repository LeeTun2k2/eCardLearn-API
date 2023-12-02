using API.Data.DTOs.Class;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using Xunit;

namespace UnitTest.Services.ClassServiceTest
{
    public class UpdateAsync_Class_Tests
    {
        private readonly Mock<IClassRepository> _mockRepository;
        private readonly Mock<ICourseInClassRepository> _mockCourseInClassRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IClassService _service;

        public UpdateAsync_Class_Tests()
        {
            _mockRepository = new Mock<IClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockCourseInClassRepository = new Mock<ICourseInClassRepository>();
            _service = new ClassService(_mockRepository.Object, _mockCourseInClassRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new ClassEditModel { ClassId = id };
            var entity = new Class { ClassId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(entity);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Class>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Class>(It.IsAny<ClassEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<ClassViewModel>(It.IsAny<Class>())).Returns(new ClassViewModel());

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ClassViewModel>(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var model = new ClassEditModel { ClassId = id };
            var entity = new Class { ClassId = id };

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Class)null!);
            _mockRepository.Setup(service => service.UpdateAsync(It.IsAny<Class>())).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<Class>(It.IsAny<ClassEditModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<ClassViewModel>(It.IsAny<Class>())).Returns((ClassViewModel)null!);

            // Act
            var result = await _service.UpdateAsync(id, model);

            // Assert
            Assert.Null(result);
        }
    }
}
