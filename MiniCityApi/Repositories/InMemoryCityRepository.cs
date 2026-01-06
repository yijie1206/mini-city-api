using MiniCityApi.DomainModel;

namespace MiniCityApi.Repositories
{
    public class InMemoryCityRepository : ICityRepository
    {

        private readonly List<CityModel> _cities;

        public InMemoryCityRepository()
        {
            _cities = new List<CityModel>
            {
                new CityModel
                {
                Id = 1,
                Name = "Auckland",
                Description = "New Zealand’s largest city"
                },

            new CityModel
            {

                Id = 2,
                Name = "Beijing",
                Description = "Capital city of China"
            }};

        }



        public IEnumerable<CityModel> GetCities()
        {
            return _cities;
        }


        public CityModel? GetCity(int cityId)
        {
            return _cities.FirstOrDefault(c => c.Id == cityId);

        }

        public CityModel AddCity(CityModel cityModel)
        {
            //ID generate
            int maxId = 1;
            foreach (var c in _cities)
            {
                if (c.Id > maxId)
                {
                    maxId = c.Id;
                }
            }
            int newId = maxId + 1;

            //new object of CityModel
            var city = new CityModel
            {
                Id = newId,
                Name = cityModel.Name,
                Description = cityModel.Description
            };
            _cities.Add(city);
            return city;

        }


        public bool UpdateCity(CityModel cityModel)
        {
            var city = _cities.FirstOrDefault(c => c.Id == cityModel.Id);
            if (city == null)
            {
                return false;
            }
            else
            {
                city.Name = cityModel.Name;
                city.Description = cityModel.Description;
                return true;
            }
        }


        public bool DeleteCity(int cityId)
        {
            var city = _cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return false;
            }
            else
            {
                _cities.Remove(city);
                return true;
            }
        }
    }
}
