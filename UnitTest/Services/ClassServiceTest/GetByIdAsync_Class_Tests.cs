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
    public class GetByIdAsync_Class_Tests
    {
        private readonly Mock<IClassRepository> _mockRepository;
        private readonly Mock<ICourseInClassRepository> _mockCourseInClassRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IClassService _service;

        public GetByIdAsync_Class_Tests()
        {
            _mockRepository = new Mock<IClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockCourseInClassRepository = new Mock<ICourseInClassRepository>();
            _service = new ClassService(_mockRepository.Object, _mockCourseInClassRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnViewModel()
        {
            // Arrange
            Guid id = Guid.NewGuid();
            var entity = new Class();
            var model = new ClassViewModel();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync(entity);

            _mockMapper.Setup(service => service.Map<ClassViewModel>(It.IsAny<Class>()))
                       .Returns(model);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<ClassViewModel>(result);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            _mockRepository.Setup(service => service.GetByIdAsync(id)).ReturnsAsync((Class)null!);

            _mockMapper.Setup(service => service.Map<ClassViewModel>(It.IsAny<Class>()))
                       .Returns((ClassViewModel)null!);

            // Act
            var result = await _service.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
