using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    /// <summary>
    /// Controller for publishing 
    /// </summary>
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HomeController()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("eCardLearn");
        }
    }
}
