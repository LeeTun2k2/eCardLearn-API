using API.Data.Constants;
using API.Data.DTOs.Class;
using API.Data.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Class Controller
    /// </summary>
    public class ClassController : BaseController
    {
        private readonly IClassService _classService;
        private readonly ILogger<ClassController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="classService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public ClassController(IClassService classService, ILogger<ClassController> logger, UserManager<User> userManager) : base(userManager)
        {
            _classService = classService;
            _logger = logger;
        }

        /// <summary>
        /// Get a list of Classs filted by Class filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] ClassFilterModel filter)
        {
            try
            {
                var views = await _classService.GetAsync(filter);
                return Ok(views);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Get Class by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClassViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var view = await _classService.GetByIdAsync(id);
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
        /// Add Class to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ClassAddModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Create([FromBody] ClassAddModel model)
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
                var view = await _classService.AddAsync(model);

                if (view == null)
                {
                    return BadRequest("Can not create object");
                }

                return CreatedAtAction(nameof(Create), new { id = view.ClassId }, view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update Class to database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClassEditModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ClassViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClassEditModel model)
        {
            try
            {
                if (id != model.ClassId)
                {
                    return BadRequest("ID in the URL does not match the ID in the request body.");
                }

                // Check existing entity
                var existingEntity = await _classService.GetByIdAsync(id);
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
                var view = await _classService.UpdateAsync(id, model);
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
        /// Delete Class from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ClassViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (await _classService.DeleteAsync(id))
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
        /// Get Class by Teacher Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ClassViewModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> GetByTeacherId(Guid id)
        {
            try
            {
                var view = await _classService.GetByTeacherId(id);
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
