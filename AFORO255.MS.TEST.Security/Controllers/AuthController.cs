using AFORO255.MS.TEST.Security.DTO;
using AFORO255.MS.TEST.Security.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MS.AFORO255.Cross.Jwt.Src;

namespace AFORO255.MS.TEST.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceAccess _serviceAccess;
        private readonly JwtOptions _jwtOption;

        public AuthController(IServiceAccess serviceAccess, IOptionsSnapshot<JwtOptions> jwtOption)
        {
            _serviceAccess = serviceAccess;
            _jwtOption = jwtOption.Value;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_serviceAccess.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequestDto requestDto)
        {
            if (!_serviceAccess.Validate(requestDto.username, requestDto.password))
            {
                return Unauthorized();
            }
            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", JwtToken.Create(_jwtOption));
            
            return Ok();
        }
    }
}