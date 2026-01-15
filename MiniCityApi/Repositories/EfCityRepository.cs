using Microsoft.EntityFrameworkCore.Diagnostics;
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


        public IEnumerable<CityModel> GetCities()
        {
            return _cityDbContext.Cities.ToList();
        }


        public CityModel? GetCity(int cityId)
        {
            return _cityDbContext.Cities.FirstOrDefault(c => c.Id == cityId);
        }


        public CityModel AddCity(CityModel cityModel)
        {
            var city = new CityModel
            {
                Name = cityModel.Name,
                Description = cityModel.Description,
            };
            var newCity = _cityDbContext.Cities.Add(city);
            _cityDbContext.SaveChanges();
            return city;
        }

        public bool UpdateCity(CityModel cityModel)
        {
            var city = _cityDbContext.Cities.FirstOrDefault(c => c.Id == cityModel.Id);
            if (city != null)
            {
                city.Name = cityModel.Name;
                city.Description = cityModel.Description;
                _cityDbContext.SaveChanges();
                return true;
            }
            return false;
        }



        public bool DeleteCity(int cityId)
        {
            var city = _cityDbContext.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city != null)
            {
                _cityDbContext.Remove(city);
                _cityDbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}