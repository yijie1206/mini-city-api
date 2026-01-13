//using Microsoft.IdentityModel.Tokens;
//using MiniCityApi.DomainModel;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//namespace MiniCityApi.Services
//{
//    public class TokenService : ITokenService
//    {
//        private IConfiguration _configuration;

//        public TokenService(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public string GetToken(CityInfoUser cityInfoUser)
//        {
//            var key = _configuration["Authentication:SecretForKey"];
//            if (key == null)
//            {
//                throw new InvalidOperationException("JWT signing key is not configured.");
//            }

//            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
//            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//            //3.claim(payload)
//            var claimForToken = new List<Claim>
//            {
//                new Claim("sub",cityInfoUser.UserId.ToString()),
//                new Claim("username", cityInfoUser.UserName),
//                new Claim("city",cityInfoUser.City),
//                new Claim("role", cityInfoUser.Role)
//            };

//            //4.create token object
//            var jwtSecurityToken = new JwtSecurityToken

//                (
//                   issuer: _configuration["Authentication:Issuer"],
//                   audience: _configuration["Authentication:Audience"],
//                   claims: claimForToken,
//                   expires: DateTime.UtcNow.AddHours(1),
//                   signingCredentials: signingCredentials

//                );

//            //5.convert token object to a JWT string 
//            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

//            return tokenToReturn;
//        }
//    }
//}
