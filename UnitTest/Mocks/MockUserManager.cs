using System.Runtime.CompilerServices;
using System.Security.Claims;
using API.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace UnitTest.Mocks
{
    public class MockUserManager
    {
        public static User user = new User
        {
            Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
            UserName = "test@email.com",
            Email = "test@email.com",
            Name = "Test",
        };

        public static UserManager<User> Mock_UserManager()
        {
            var store = new Mock<IUserStore<User>>();
            store.Setup(x => x.FindByIdAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((string userId, CancellationToken token) =>
                {
                    // Mock finding a user by ID
                    if (userId == user.Id.ToString())
                    {
                        return user;
                    }

                    return null;
                });

            var mgr = new UserManager<User>(store.Object, null!, null!, null!, null!, null!, null!, null!, null!);
            return mgr;
        }
    }
}
