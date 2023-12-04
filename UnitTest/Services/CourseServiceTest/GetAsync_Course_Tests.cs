using API.Commons.Paginations;
using API.Data.DTOs.Course;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace UnitTest.Services.CourseServiceTest
{
    public class GetAsync_Course_Tests
    {
        private readonly Mock<ICourseRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ICourseService _service;

        public GetAsync_Course_Tests()
        {
            _mockRepository = new Mock<ICourseRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new CourseService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new CourseFilterModel();
            var entities = new List<Course> { new Course (), new Course () };
            var models = new List<CourseViewModel> { new CourseViewModel(), new CourseViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Course, bool>>>(),
                    It.IsAny<Func<IQueryable<Course>, IOrderedQueryable<Course>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<CourseViewModel>>(It.IsAny<IEnumerable<Course>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<CourseViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new CourseFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<Course, bool>>>(),
                    It.IsAny<Func<IQueryable<Course>, IOrderedQueryable<Course>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<Course>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<CourseViewModel>>(It.IsAny<IEnumerable<Course>>()))
                       .Returns((IEnumerable<CourseViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
