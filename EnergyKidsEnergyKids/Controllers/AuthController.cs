using Microsoft.AspNetCore.Mvc;

namespace EnergyKids.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController() { }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(string token)
        {
            return Ok("Autenticação não implementada.");
        }
    }
}
