using API.Data.Constants;
using API.Data.DTOs.UserLoginHistory;
using API.Data.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// UserLoginHistory Controller
    /// </summary>
    public class UserLoginHistoryController : BaseController
    {
        private readonly IUserLoginHistoryService _topicService;
        private readonly ILogger<UserLoginHistoryController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="topicService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public UserLoginHistoryController(IUserLoginHistoryService topicService, ILogger<UserLoginHistoryController> logger, UserManager<User> userManager) : base(userManager)
        {
            _topicService = topicService;
            _logger = logger;
        }

        /// <summary>
        /// Get UserLoginHistory by User Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUserId(Guid id)
        {
            try
            {
                var view = await _topicService.GetUserLoginHistory(id);
                if (view == null)
                {
                    return NotFound();
                }
                return Ok(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
