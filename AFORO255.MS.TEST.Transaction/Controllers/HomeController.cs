using Microsoft.AspNetCore.Mvc;

namespace AFORO255.MS.TEST.Transaction.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping() => Ok();
    }
}