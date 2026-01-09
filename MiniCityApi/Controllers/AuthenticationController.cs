
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiniCityApi.DTOs;
using MiniCityApi.Services;
using System.Text;



namespace MiniCityApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {

        private IAuthenticationService _authenticationService;

        private IConfiguration _configuration;

        public AuthenticationController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }



        [HttpPost("login")]
        public ActionResult<String> Login(AuthenticationRequestBodyDto authenticationRequestBody)
        {
            var key = _configuration["Authentication:SecretForKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var validateCredential = _authenticationService.ValidateCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password);
            if (validateCredential == null)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
}
