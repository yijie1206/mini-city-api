using MiniCityApi.DomainModel;

namespace MiniCityApi.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<CityModel> GetCities();

        CityModel? GetCity(int cityId);

        CityModel AddCity(CityModel cityModel);

        bool UpdateCity(CityModel cityModel);

        bool DeleteCity(int cityId);

    }
}
