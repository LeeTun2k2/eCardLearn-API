using API.Data.Constants;
using API.Data.DTOs.Authentication;
using API.Data.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    /// <summary>
    /// Authentication Controller
    /// </summary>
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AuthenticationController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService">Authentication</param>
        /// <param name="logger">Logger on server</param>
        /// <param name="userManager">User manager</param>
        public AuthenticationController(
            IAuthenticationService authenticationService, 
            ILogger<AuthenticationController> logger, 
            UserManager<User> userManager) 
            : base(userManager)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        /// <summary>
        /// Register a new user, but do not set up user's role yet.
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _authenticationService.Register(userModel);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    string message = $"Registration attempt failed. ErrorCode: {error.Code}. Description: {error.Description}";
                    _logger.LogInformation(message);
                }

                return BadRequest(new { result.Errors });
            }

            return Ok(new { result.Succeeded });
        }

        /// <summary>
        /// Request role for student and teacher after register.
        /// </summary>
        /// <param name="setup"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> RequestRole([FromBody] SetUserRole setup)
        {
            // Get user id
            User? user = await GetHttpContextUser();
            if (user == null)
            {
                return NotFound();
            }

            // Validate user role
            string userRole = string.Empty;
            if (setup.UserRole == UserRoles.Student || setup.UserRole == UserRoles.Teacher)
            {
                userRole = setup.UserRole;
            }
            else
            {
                return BadRequest("Invalid user's role");
            }

            // Set role
            var result = await _userManager.AddToRoleAsync(user, userRole);

            if (!result.Succeeded)
            {
                return BadRequest("Can not set up user's role");
            }

            return Ok(new { result.Succeeded });
        }

        /// <summary>
        /// Confirm email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([Required] string email, [Required] string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
            {
                return NotFound();
            }

            var result = await _authenticationService.ConfirmEmail(email, token);

            if (!result.Succeeded)
            {
                return BadRequest(new { result.Errors });
            }

            return Ok(new { result.Succeeded });
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _authenticationService.Login(loginModel);

            var token = result.Item1;
            var userVM = result.Item2;

            if (string.IsNullOrEmpty(token) || userVM is null)
            {
                return Unauthorized(new { Error = token });
            }

            return Ok(new { Token = token, User = userVM });
        }

        /// <summary>
        /// Forgot password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([Required] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _authenticationService.ForgotPassword(email);

            if (result.Succeeded)
            {
                return Ok();
            }

            var errors = result.Errors.Select(error => error.Description);
            return BadRequest(errors);
        }

        /// <summary>
        /// Reset password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        public async Task<IActionResult> ResetPassword([Required] string email, [Required] string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _authenticationService.ResetPassword(email, token);

            if (result.Succeeded)
            {
                return Ok();
            }

            var errors = result.Errors.Select(error => error.Description);
            return BadRequest(errors);
        }

        /// <summary>
        /// Change password
        /// </summary>
        /// <param name="changePasswordModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePasswordModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _authenticationService.ChangePassword(changePasswordModel);

            if (result.Succeeded)
            {
                return Ok();
            }

            var errors = result.Errors.Select(error => error.Description);
            return BadRequest(errors);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("[action]")]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            Response.Cookies.Delete("token");
            return Ok();
        }

        /// <summary>
        /// Admin Lock User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        [Authorize(Roles = $"{UserRoles.Admin}")]
        public async Task<IActionResult> LockUser([Required] string email)
        {
            var result = await _authenticationService.LockUser(email);

            if (result.Item1)
            {
                return Ok(result.Item2);
            }

            return BadRequest(result.Item2);
        }

        /// <summary>
        /// Admin Unlock User
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        [Authorize(Roles = $"{UserRoles.Admin}")]
        public async Task<IActionResult> UnlockUser([Required] string email)
        {
            var result = await _authenticationService.UnlockUser(email);

            if (result.Item1)
            {
                return Ok(result.Item2);
            }

            return BadRequest(result.Item2);
        }

        /// <summary>
        /// Admin Set Role 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        [Authorize(Roles = $"{UserRoles.Admin}")]
        public async Task<IActionResult> AdminSetRole([Required] string email, [Required] string roleName)
        {
            var result = await _authenticationService.AdminSetRole(email, roleName);

            if (result.Item1)
            {
                return Ok(result.Item2);
            }

            return BadRequest(result.Item2);
        }

        /// <summary>
        /// Admin Remove Role 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("[action]")]
        [Authorize(Roles = $"{UserRoles.Admin}")]
        public async Task<IActionResult> AdminRemoveRole([Required] string email, [Required] string roleName)
        {
            var result = await _authenticationService.AdminRemoveRole(email, roleName);

            if (result.Item1)
            {
                return Ok(result.Item2);
            }

            return BadRequest(result.Item2);
        }
    }
}
