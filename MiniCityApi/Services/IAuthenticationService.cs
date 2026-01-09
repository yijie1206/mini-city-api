namespace MiniCityApi.Repositories
{
    public interface IAuthenticationService
    {

        CityInfoUser ValiateCredentials(string? UserName, string? Password);
    }
}
