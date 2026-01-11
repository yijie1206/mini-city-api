using MiniCityApi.DomainModel;

namespace MiniCityApi.Services
{
    public interface IAuthenticationService
    {

        CityInfoUser? ValidateCredentials(string? UserName, string? Password);
    }
}
