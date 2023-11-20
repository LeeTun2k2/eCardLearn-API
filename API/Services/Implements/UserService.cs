using API.Data.Constants;
using API.Data.DTOs.Authentication;
using API.Data.Entities;
using API.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Implements
{
    /// <summary>
    /// User service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructort
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="mapper"></param>
        public UserService(UserManager<User> userManager, IMapper mapper) 
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        /// <summary>
        /// Find User
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>

        public async Task<IEnumerable<UserProfileModel>?> FindUser(string? name, string? email)
        {
            var students = await FindStudent(name, email) ?? new List<UserProfileModel>();
            var teachers = await FindTeacher(name, email) ?? new List<UserProfileModel>();

            var users = new List<UserProfileModel>();
            foreach (var student in students)
            {
                users.Add(_mapper.Map<UserProfileModel>(student));
            }

            foreach (var teacher in teachers)
            {
                users.Add(_mapper.Map<UserProfileModel>(teacher));
            }

            if (users.Count == 0)
                return null;

            return _mapper.Map<IEnumerable<UserProfileModel>?>(users);
        }

        /// <summary>
        /// Find Student
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>

        public async Task<IEnumerable<UserProfileModel>?> FindStudent(string? name, string? email)
        {
            var allStudents = await _userManager.GetUsersInRoleAsync(UserRoles.Student);

            var students = allStudents;

            if (name != null)
            {
                students = students
                    .Where(x => x.Name.Contains(name))
                    .ToList();
            }

            if (email != null)
            {
                students = students
                    .Where(x => x.Email!.Contains(email))
                    .ToList();
            }

            return _mapper.Map<IEnumerable<UserProfileModel>?>(students);
        }

        /// <summary>
        /// Find Teacher
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <returns></returns>

        public async Task<IEnumerable<UserProfileModel>?> FindTeacher(string? name, string? email)
        {
            var allTeachers = await _userManager.GetUsersInRoleAsync(UserRoles.Teacher);

            var teachers = allTeachers;

            if (name != null)
            {
                teachers = teachers
                    .Where(x => x.Name.Contains(name))
                    .ToList();
            }

            if (email != null)
            {
                teachers = teachers
                    .Where(x => x.Email!.Contains(email))
                    .ToList();
            }

            return _mapper.Map<IEnumerable<UserProfileModel>?>(teachers);
        }

        /// <summary>
        /// Find student by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<UserProfileModel?> FindUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<UserProfileModel>(user);
        }

        /// <summary>
        /// Find student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserProfileModel?> FindUserById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<UserProfileModel>(user);
        }
    }
}
