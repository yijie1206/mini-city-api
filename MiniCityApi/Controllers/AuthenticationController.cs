
using Microsoft.AspNetCore.Mvc;
using MiniCityApi.DTOs;
using MiniCityApi.Services;



namespace MiniCityApi.Controllers
{
    [Route("api/authentication")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {

        private Microsoft.AspNetCore.Authentication.IAuthenticationService _authenticationService;

        public AuthenticationController(Microsoft.AspNetCore.Authentication.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;

        }

        [HttpPost("login")]
        public ActionResult<String> Login(AuthenticationRequestBodyDto authenticationRequestBody)
        {
            var validateCredential = _authenticationService.ValidateCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password);
            if ()
            {

            }
        }


    }
}
