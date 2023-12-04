using API.Commons.Paginations;
using API.Data.DTOs.StudentJoinClass;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.StudentJoinClassServiceTest
{
    public class GetAsync_StudentJoinClass_Tests
    {
        private readonly Mock<IStudentJoinClassRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinClassService _service;

        public GetAsync_StudentJoinClass_Tests()
        {
            _mockRepository = new Mock<IStudentJoinClassRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinClassService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new StudentJoinClassFilterModel();
            var entities = new List<StudentJoinClass> { new StudentJoinClass (), new StudentJoinClass () };
            var models = new List<StudentJoinClassViewModel> { new StudentJoinClassViewModel(), new StudentJoinClassViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<StudentJoinClass, bool>>>(),
                    It.IsAny<Func<IQueryable<StudentJoinClass>, IOrderedQueryable<StudentJoinClass>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<StudentJoinClassViewModel>>(It.IsAny<IEnumerable<StudentJoinClass>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<StudentJoinClassViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new StudentJoinClassFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<StudentJoinClass, bool>>>(),
                    It.IsAny<Func<IQueryable<StudentJoinClass>, IOrderedQueryable<StudentJoinClass>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<StudentJoinClass>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<StudentJoinClassViewModel>>(It.IsAny<IEnumerable<StudentJoinClass>>()))
                       .Returns((IEnumerable<StudentJoinClassViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
