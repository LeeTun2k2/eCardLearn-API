using API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Commons.Utils.CloudinaryService;

namespace API.Controllers
{
    /// <summary>
    /// Cloudinary Controller
    /// </summary>
    public class CloudinaryController : BaseController
    {
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILogger<CloudinaryController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cloudinaryService"></param>
        /// <param name="logger"></param>
        /// <param name="userManager"></param>
        public CloudinaryController(
            ICloudinaryService cloudinaryService, 
            ILogger<CloudinaryController> logger, 
            UserManager<User> userManager) : base(userManager)
        { 
            _cloudinaryService = cloudinaryService;
            _logger = logger;
        }

        /// <summary>
        /// Get file url
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetUrl(string publicId)
        {
            if (string.IsNullOrEmpty(publicId))
            {
                return BadRequest("PublicId is required.");
            }

            return Ok(_cloudinaryService.GetUrl(publicId));
        }

        /// <summary>
        /// Upload image controller
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length < 1)
                return BadRequest("No such file.");

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
            {
                return BadRequest("Invalid file extension. Allowed extensions are: " + string.Join(", ", allowedExtensions));
            }

            try
            {
                var result = await _cloudinaryService.Upload(file);   

                if (result.Item1)
                {
                    return Ok(new { 
                            publicId = result.Item2,
                            url = _cloudinaryService.GetUrl(result.Item2)
                        }
                    );
                }

                return BadRequest("Fail to upload images");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error while uploading image.");
            }
        }

        /// <summary>
        /// Remove file
        /// </summary>
        /// <param name="publicId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("publicId")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveFile(string publicId)
        {
            if (string.IsNullOrEmpty(publicId))
            {
                return BadRequest("PublicId is required.");
            }

            try
            {
                var result = await _cloudinaryService.Remove(publicId);

                if (result.Item1)
                {
                    return Ok(result.Item2);
                }

                return BadRequest("Fail to upload images");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Error while uploading image.");
            }
        }
    }
}
