using MiniCityApi.DomainModel;
using MiniCityApi.DTOs;

namespace MiniCityApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private const string ValidUserName = "xiaomila";
        private const string ValidPassWord = "Password123";
        public CityInfoUser? ValidateCredentials(string? UserName, string? Password)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                return null;
            }

            if (UserName != ValidUserName || Password != ValidPassWord)
            {
                return null;
            }

            return new CityInfoUser
            {
                UserId = 1,
                UserName = "xiaomila",
                City = "Auckland",
                Role = "Admin"
            };
        }
    }
}
