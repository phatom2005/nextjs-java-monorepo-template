using Microsoft.AspNetCore.Mvc;

namespace ProjectTemplate_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "Backend is working with Swagger!" });
        }
    }
}