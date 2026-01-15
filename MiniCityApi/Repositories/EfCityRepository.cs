using MiniCityApi.Data;
using MiniCityApi.DomainModel;

namespace MiniCityApi.Repositories
{
    public class EfCityRepository : ICityRepository
    {
        private readonly CityDbContext _cityDbContext;

        public EfCityRepository(CityDbContext cityDbContext) 
        {
            _cityDbContext = cityDbContext;
        }

        CityModel ICityRepository.AddCity(CityModel cityModel)
        {
            throw new NotImplementedException();
        }

        bool ICityRepository.DeleteCity(int cityId)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CityModel> ICityRepository.GetCities()
        {
            throw new NotImplementedException();
        }

        CityModel? ICityRepository.GetCity(int cityId)
        {
            throw new NotImplementedException();
        }

        bool ICityRepository.UpdateCity(CityModel cityModel)
        {
            throw new NotImplementedException();
        }
    }
}
