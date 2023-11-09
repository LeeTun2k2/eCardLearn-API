using API.Data.Constants;
using API.Data.DTOs.Feedback;
using API.Data.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
	/// <summary>
	/// Feedback Controller
	/// </summary>
	public class FeedbackController : BaseController
    {
        private readonly IFeedbackService _feedbackService;
        private readonly ILogger<FeedbackController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="feedbackService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public FeedbackController(IFeedbackService feedbackService, ILogger<FeedbackController> logger, UserManager<User> userManager) : base(userManager)
        {
            _feedbackService = feedbackService;
            _logger = logger;
        }

        /// <summary>
        /// Get a list of Feedbacks filted by Feedback filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] FeedbackFilterModel filter)
        {
            try
            {
                var views = await _feedbackService.GetAsync(filter);
                return Ok(views);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Get Feedback by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FeedbackViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var view = await _feedbackService.GetByIdAsync(id);
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

        /// <summary>
        /// Add Feedback to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(FeedbackAddModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Create([FromBody] FeedbackAddModel model)
        {
            try
            {
                // Get date time
                var today = DateTime.Today;
                var contextUser = await GetHttpContextUser();
                var userId = contextUser?.Id;

                // Log user id, date
                model.CreatedUserId = userId;
                model.CreatedDate = DateTime.Today;
                model.UpdatedUserId = null;
                model.UpdatedDate = null;

                // Add
                var view = await _feedbackService.AddAsync(model);

                if (view == null)
                {
                    return BadRequest("Can not create object");
                }

                return CreatedAtAction(nameof(Create), new { id = view.FeedbackId }, view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update Feedback to database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FeedbackEditModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FeedbackViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] FeedbackEditModel model)
        {
            try
            {
                if (id != model.FeedbackId)
                {
                    return BadRequest("ID in the URL does not match the ID in the request body.");
                }

                // Check existing entity
                var existingEntity = await _feedbackService.GetByIdAsync(id);
                if (existingEntity == null)
                {
                    return NotFound();
                }

                // Get date time
                var today = DateTime.Today;
                var contextUser = await GetHttpContextUser();
                var userId = contextUser?.Id;

                // Log user id, date
                model.CreatedUserId = existingEntity.CreatedUserId;
                model.CreatedDate = existingEntity.CreatedDate;
                model.UpdatedUserId = userId;
                model.UpdatedDate = DateTime.Today;

                // Update
                var view = await _feedbackService.UpdateAsync(id, model);
                if (view == null)
                {
                    return BadRequest("Can not update object");
                }

                return Ok(view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Delete Feedback from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(FeedbackViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (await _feedbackService.DeleteAsync(id))
                {
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
