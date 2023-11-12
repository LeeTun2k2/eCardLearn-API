using API.Data.DTOs.Question;
using API.Data.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Question Controller
    /// </summary>
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService;
        private readonly ILogger<QuestionController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="questionService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public QuestionController(IQuestionService questionService, ILogger<QuestionController> logger, UserManager<User> userManager) : base(userManager)
        {
            _questionService = questionService;
            _logger = logger;
        }

        /// <summary>
        /// Get a list of Questions filted by Question filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] QuestionFilterModel filter)
        {
            try
            {
                var views = await _questionService.GetAsync(filter);
                return Ok(views);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Get Question by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(QuestionViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var view = await _questionService.GetByIdAsync(id);
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
        /// Add Question to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(QuestionAddModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Create([FromBody] QuestionAddModel model)
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
                var view = await _questionService.AddAsync(model);

                if (view == null)
                {
                    return BadRequest("Can not create object");
                }

                return CreatedAtAction(nameof(Create), new { id = view.QuestionId }, view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update Question to database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(QuestionEditModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(QuestionViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] QuestionEditModel model)
        {
            try
            {
                if (id != model.QuestionId)
                {
                    return BadRequest("ID in the URL does not match the ID in the request body.");
                }

                // Check existing entity
                var existingEntity = await _questionService.GetByIdAsync(id);
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
                var view = await _questionService.UpdateAsync(id, model);
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
        /// Delete Question from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(QuestionViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (await _questionService.DeleteAsync(id))
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

        /// <summary>
        /// Get Question by Course Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(QuestionViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> GetByCourseId(Guid id)
        {
            try
            {
                var view = await _questionService.GetByCourseId(id);
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
