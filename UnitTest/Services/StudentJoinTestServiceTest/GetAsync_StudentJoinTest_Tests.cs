using API.Commons.Paginations;
using API.Data.DTOs.StudentJoinTest;
using API.Data.Entities;
using API.Data.Repositories.Interfaces;
using API.Services.Implements;
using API.Services.Interfaces;
using AutoMapper;
using Moq;
using System.Linq.Expressions;
using UnitTest.Mocks;
using Xunit;

namespace UnitTest.Services.StudentJoinTestServiceTest
{
    public class GetAsync_StudentJoinTest_Tests
    {
        private readonly Mock<IStudentJoinTestRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly IStudentJoinTestService _service;

        public GetAsync_StudentJoinTest_Tests()
        {
            _mockRepository = new Mock<IStudentJoinTestRepository>();
            _mockMapper = new Mock<IMapper>();
            var userManager = MockUserManager.Mock_UserManager();
            _service = new StudentJoinTestService(_mockRepository.Object, userManager, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnViewModel()
        {
            // Arrange
            var filter = new StudentJoinTestFilterModel();
            var entities = new List<StudentJoinTest> { new StudentJoinTest (), new StudentJoinTest () };
            var models = new List<StudentJoinTestViewModel> { new StudentJoinTestViewModel(), new StudentJoinTestViewModel() };

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<StudentJoinTest, bool>>>(),
                    It.IsAny<Func<IQueryable<StudentJoinTest>, IOrderedQueryable<StudentJoinTest>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync(entities);

            _mockMapper.Setup(service => service.Map<IEnumerable<StudentJoinTestViewModel>>(It.IsAny<IEnumerable<StudentJoinTest>>()))
                       .Returns(models);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<StudentJoinTestViewModel>>(result);
            Assert.Equal(models.Count, result.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnNull()
        {
            // Arrange
            var filter = new StudentJoinTestFilterModel();

            _mockRepository.Setup(service =>
                service.GetAsync(
                    It.IsAny<Expression<Func<StudentJoinTest, bool>>>(),
                    It.IsAny<Func<IQueryable<StudentJoinTest>, IOrderedQueryable<StudentJoinTest>>>(),
                    It.IsAny<PaginationParameters>()
                )
            ).ReturnsAsync((IEnumerable<StudentJoinTest>)null!);

            _mockMapper.Setup(service => service.Map<IEnumerable<StudentJoinTestViewModel>>(It.IsAny<IEnumerable<StudentJoinTest>>()))
                       .Returns((IEnumerable<StudentJoinTestViewModel>)null!);

            // Act
            var result = await _service.GetAsync(filter);

            // Assert
            Assert.Null(result);
        }
    }
}
