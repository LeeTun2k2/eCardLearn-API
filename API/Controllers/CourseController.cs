﻿using API.Data.Constants;
using API.Data.DTOs.Course;
using API.Data.Entities;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Course Controller
    /// </summary>
    public class CourseController : BaseController
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="courseService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public CourseController(ICourseService courseService, ILogger<CourseController> logger, UserManager<User> userManager) : base(userManager)
        {
            _courseService = courseService;
            _logger = logger;
        }

        /// <summary>
        /// Get a list of Courses filted by Course filter model
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] CourseFilterModel filter)
        {
            try
            {
                var views = await _courseService.GetAsync(filter);
                return Ok(views);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Get Course by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var view = await _courseService.GetById(id);
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
        /// Add Course to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Create([FromBody] CourseAddModel model)
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
                var view = await _courseService.AddAsync(model);

                if (view == null)
                {
                    return BadRequest("Can not create object");
                }

                return CreatedAtAction(nameof(Create), new { id = view.CourseId }, view);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, "Internal Server Error");
            }
        }

        /// <summary>
        /// Update Course to database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CourseEditModel model)
        {
            try
            {
                if (id != model.CourseId)
                {
                    return BadRequest("ID in the URL does not match the ID in the request body.");
                }

                // Check existing entity
                var existingEntity = await _courseService.GetByIdAsync(id);
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
                var view = await _courseService.UpdateAsync(id, model);
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
        /// Delete Course from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize(Roles = $"{UserRoles.Teacher}, {UserRoles.Admin}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (await _courseService.DeleteAsync(id))
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
        /// Get Course by Teacher Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> GetByTeacherId(Guid id)
        {
            try
            {
                var view = await _courseService.GetByTeacherId(id);
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
        /// Get Course by Topic Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Authorize]
        public async Task<IActionResult> GetByTopicId(Guid id)
        {
            try
            {
                var view = await _courseService.GetByTopicId(id);
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
