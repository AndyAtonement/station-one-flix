using Microsoft.AspNetCore.Mvc;

namespace StationOneFlix.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}

