using API.Commons.Paginations;
using API.Data.DTOs.Class;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.ClassServiceTest
{
    public class GetAsync_Class_Tests
    {
        private readonly Mock<IClassRepository> _mockRepository;
        private readonly Mock<ICourseInClassRepository> _mockCourseInClassRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IClassService _service;

        public GetAsync_Class_Tests()
        {
            _mockRepository = new Mock<IClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockCourseInClassRepository = new Mock<ICourseInClassRepository>();
            _service = new ClassService(_mockRepository.Object, _mockCourseInClassRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new ClassFilterModel();
            var entities = new List<Class> { new Class (), new Class () };
            var models = new List<ClassViewModel> { new ClassViewModel(), new ClassViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Class, bool>>>(),
                    It.IsAny<Func<IQueryable<Class>, IOrderedQueryable<Class>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<ClassViewModel>>(It.IsAny<IEnumerable<Class>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<ClassViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new ClassFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Class, bool>>>(),
                    It.IsAny<Func<IQueryable<Class>, IOrderedQueryable<Class>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<Class>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<ClassViewModel>>(It.IsAny<IEnumerable<Class>>()))
                       .Returns((IEnumerable<ClassViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
