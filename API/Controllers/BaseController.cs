using API.Data.Entities;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// User Manager
        /// </summary>
        protected readonly UserManager<User> _userManager;

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Get Http context user
        /// </summary>
        /// <returns></returns>
        protected async Task<User?> GetHttpContextUser()
        {
            var userId = Request.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(userId);

            return user;
        }
    }
}

