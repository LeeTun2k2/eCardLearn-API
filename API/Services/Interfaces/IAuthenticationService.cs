﻿using API.Data.Constants;
using API.Data.DTOs.Authentication;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Interfaces
{
    /// <summary>
    /// Authentication service
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Register new user
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        public Task<IdentityResult> Register(RegisterModel registerModel);

        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IdentityResult> ConfirmEmail(string email, string token);

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public Task<(string, UserProfileModel?)> Login(LoginModel loginModel);

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<IdentityResult> ForgotPassword(string email);

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<IdentityResult> ResetPassword(string email, string token);

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="changePasswordModel"></param>
        /// <returns></returns>
        public Task<IdentityResult> ChangePassword(ChangePasswordModel changePasswordModel);

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        public Task Logout();

        /// <summary>
        /// Lock user account
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<(bool, string)> LockUser(string email);

        /// <summary>
        /// Un lock user account
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<(bool, string)> UnlockUser(string email);

        /// <summary>
        /// Admin set role for user.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<(bool, string)> AdminSetRole(string email, string roleName);

        /// <summary>
        /// Admin remove role for user.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task<(bool, string)> AdminRemoveRole(string email, string roleName);
    }
}
