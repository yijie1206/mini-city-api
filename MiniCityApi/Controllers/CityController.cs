using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCityApi.Model;

namespace MiniCityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            var cities = new List<CityDto>

            {
                new CityDto
                {
                Id = 1,
                Name = "Auckland",
                Description = "Mila's birth place"
                },

            new CityDto
            {

                Id = 2,
                Name = "Beijing",
                Description = "Capital city of China"
            }};
            return cities;

        }
    }

}
