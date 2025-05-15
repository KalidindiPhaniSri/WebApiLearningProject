using Microsoft.AspNetCore.Mvc;

namespace WebApiLearningProject.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult TestMethod()
        {
            return Ok("Hey you got result from API");
        }
    }
}
