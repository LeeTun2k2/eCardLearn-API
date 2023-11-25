using API.Data.DTOs.Authentication;
using API.Data.Entities;

namespace API.Services.Interfaces
{
    /// <summary>
    /// User Service Interface
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Find user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserProfileModel?> FindUserById(Guid id);

        /// <summary>
        /// Find user by Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserProfileModel?> FindUserByEmail(string email);

        /// <summary>
        /// Find user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<IEnumerable<UserProfileModel>?> FindUser(string? name, string? email);

        /// <summary>
        /// Find student
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<IEnumerable<UserProfileModel>?> FindStudent(string? name, string? email);

        /// <summary>
        /// Find teacher
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<IEnumerable<UserProfileModel>?> FindTeacher(string? name, string? email);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="updateModel"></param>
        /// <returns></returns>
        Task<UserProfileModel?> UpdateUser(User user, UserProfileModel updateModel);
    }
}
