
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MiniCityApi.DTOs;
using MiniCityApi.Services;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            if (key == null)
            {
                throw new InvalidOperationException("JWT signing key is not configured.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //validate input for authentication request body
            var validateCredential = _authenticationService.ValidateCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password);
            if (validateCredential == null)
            {
                return Unauthorized();
            }

            var claimForToken = new List<Claim>
            {
                new Claim("sub",validateCredential.UserId.ToString()),
                new Claim("username", validateCredential.UserName),
                new Claim("city",validateCredential.City),
                new Claim("role", validateCredential.Role)
            };

            //create token object
            var jwtSecurityToken = new JwtSecurityToken

                (
                   issuer: _configuration["Authentication:Issuer"],
                   audience: _configuration["Authentication:Audience"],
                   claims: claimForToken,
                   expires: DateTime.UtcNow.AddHours(1),
                   signingCredentials: signingCredentials

                );

            //convert token object to a JWT string 
            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);


        }
    }
}
