using API.Data.DTOs.TestAnswer;
using API.Data.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// TestAnswer Controller
    /// </summary>
    public class TestAnswerController : BaseController
    {
        private readonly ITestAnswerService _testAnswerService;
        private readonly ILogger<TestAnswerController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="testAnswerService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public TestAnswerController(ITestAnswerService testAnswerService, ILogger<TestAnswerController> logger, UserManager<User> userManager) : base(userManager)
        {
            _testAnswerService = testAnswerService;
            _logger = logger;
        }

        /// <summary>
        /// Get a list of TestAnswers filted by TestAnswer filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] TestAnswerFilterModel filter)
        {
            try
            {
                var views = await _testAnswerService.GetAsync(filter);
                return Ok(views);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Get TestAnswer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TestAnswerViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var view = await _testAnswerService.GetByIdAsync(id);
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
        /// Add TestAnswer to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(TestAnswerAddModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Create([FromBody] TestAnswerAddModel model)
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
                var view = await _testAnswerService.AddAsync(model);

                if (view == null)
                {
                    return BadRequest("Can not create object");
                }

                return CreatedAtAction(nameof(Create), new { id = view.TestAnswerId }, view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update TestAnswer to database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TestAnswerEditModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(TestAnswerViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TestAnswerEditModel model)
        {
            try
            {
                if (id != model.TestAnswerId)
                {
                    return BadRequest("ID in the URL does not match the ID in the request body.");
                }

                // Check existing entity
                var existingEntity = await _testAnswerService.GetByIdAsync(id);
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
                var view = await _testAnswerService.UpdateAsync(id, model);
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
        /// Delete TestAnswer from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(TestAnswerViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (await _testAnswerService.DeleteAsync(id))
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
