using API.Commons.Paginations;
using API.Data.DTOs.CourseInClass;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.CourseInClassServiceTest
{
    public class GetAsync_CourseInClass_Tests
    {
        private readonly Mock<ICourseInClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseInClassService _service;

        public GetAsync_CourseInClass_Tests()
        {
            _mockRepository = new Mock<ICourseInClassRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseInClassService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new CourseInClassFilterModel();
            var entities = new List<CourseInClass> { new CourseInClass (), new CourseInClass () };
            var models = new List<CourseInClassViewModel> { new CourseInClassViewModel(), new CourseInClassViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<CourseInClass, bool>>>(),
                    It.IsAny<Func<IQueryable<CourseInClass>, IOrderedQueryable<CourseInClass>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<CourseInClassViewModel>>(It.IsAny<IEnumerable<CourseInClass>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<CourseInClassViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new CourseInClassFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<CourseInClass, bool>>>(),
                    It.IsAny<Func<IQueryable<CourseInClass>, IOrderedQueryable<CourseInClass>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<CourseInClass>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<CourseInClassViewModel>>(It.IsAny<IEnumerable<CourseInClass>>()))
                       .Returns((IEnumerable<CourseInClassViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
