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
    public class AddAsync_Class_Tests
    {
        private readonly Mock<IClassRepository> _mockRepository;
        private readonly Mock<ICourseInClassRepository> _mockCourseInClassRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IClassService _service;

        public AddAsync_Class_Tests()
        {
            _mockRepository = new Mock<IClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockCourseInClassRepository = new Mock<ICourseInClassRepository>();
            _service = new ClassService(_mockRepository.Object, _mockCourseInClassRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnViewModel()
        {
            // Arrange
            var model = new ClassAddModel { };

            var entity = new Class { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Class>())).ReturnsAsync(new Class { ClassId = Guid.NewGuid() });
            _mockMapper.Setup(service => service.Map<Class>(It.IsAny<ClassAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<ClassViewModel>(It.IsAny<Class>())).Returns(new ClassViewModel { });

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ClassViewModel>(result);
        }

        [Fact]
        public async Task AddAsync_ShouldReturnNull()
        {
            // Arrange
            var model = new ClassAddModel { };

            var entity = new Class { };

            _mockRepository.Setup(service => service.AddAsync(It.IsAny<Class>())).ReturnsAsync((Class)null!);
            _mockMapper.Setup(service => service.Map<Class>(It.IsAny<ClassAddModel>())).Returns(entity);
            _mockMapper.Setup(service => service.Map<ClassViewModel>(It.IsAny<Class>())).Returns((ClassViewModel)null!);

            // Act
            var result = await _service.AddAsync(model);

            // Assert
            Assert.Null(result);
        }
    }
}
