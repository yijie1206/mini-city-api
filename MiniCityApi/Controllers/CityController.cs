using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCityApi.DomainModel;
using MiniCityApi.DTOs;
using MiniCityApi.Model;
using MiniCityApi.Repositories;
using System.Security.Cryptography.Xml;

namespace MiniCityApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CityController : ControllerBase
    {


        //private static List<CityModel> _citiesModel;

        //public CityController()
        //{
        //    if (_citiesModel == null)
        //    {

        //        _citiesModel = new List<CityModel>
        //    {
        //        new CityModel
        //        {
        //        Id = 1,
        //        Name = "Auckland",
        //        Description = "New Zealand’s largest city"
        //        },

        //    new CityModel
        //    {

        //        Id = 2,
        //        Name = "Beijing",
        //        Description = "Capital city of China"
        //    }};

        //    }

        //}

        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;


        }



        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {

            return Ok(_cityRepository.GetCities());
        }


        [HttpGet("{cityId}")]
        public ActionResult<CityDto> GetCity(int cityId)
        {
            //var city = _citiesModel.FirstOrDefault(c => c.Id == cityId);
            var city = _cityRepository.GetCity(cityId);
            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(city);
            }
        }

        [HttpPost]
        public ActionResult<CityDto> CreateCity([FromBody] CreateCityDto createCityDto)
        {
            //1.validate DTO
            if (string.IsNullOrWhiteSpace(createCityDto.Name))
            {
                return BadRequest("City name is required.");
            }

            //2.Build domain model
            //declear cityModel variable so it can be used in AddCity method call below
            var cityModel = new CityModel
            {
                Name = createCityDto.Name,
                Description = createCityDto.Description,

            };

            // 3. Call repository
            var city = _cityRepository.AddCity(cityModel);
            ////2.
            //int maxId = 1;
            //foreach (var c in _citiesModel)
            //{
            //    if (c.Id > maxId)
            //    {
            //        maxId = c.Id;
            //    }
            //}
            //int newId = maxId + 1;

            //3.
            //can be improved this part.check GPT
            //CityDto city = new CityDto();/
            //city.Id = newId;
            //city.Name = createCityDto.Name;
            //city.Description = createCityDto.Description;
            //var city = new CityModel
            //{
            //    Id = newId,
            //    Name = createCityDto.Name,
            //    Description = createCityDto.Description,

            //};


            ////4.
            //_citiesModel.Add(city);
            //5.
            return CreatedAtAction
                (
                "GetCity",
                new { cityId = city.Id },
                city
                );
        }


        [HttpPut("{cityId}")]

        public IActionResult UpdateCity(int cityId, [FromBody] UpdateCityDto updateCityDto)
        {
            //validate input
            if (string.IsNullOrEmpty(updateCityDto.Name))
            {
                return BadRequest("City name is required.");
            }

            var cityModel = new CityModel
            {
                Id = cityId,
                Name = updateCityDto.Name,
                Description = updateCityDto.Description,
            };



            var city = _cityRepository.UpdateCity(cityModel);
            //var city = _citiesModel.FirstOrDefault(c => c.Id == cityId);
            if (!city)
            {
                return NotFound();
            }
            //else
            //{
            //    //validate input
            //    if (string.IsNullOrEmpty(updateCityDto.Name))
            //    {
            //        return BadRequest("City name is required.");
            //    }
                else
                {
                //    city.Name = updateCityDto.Name;
                //    city.Description = updateCityDto.Description;
                //}
            }
            return NoContent();
        }


        [HttpDelete("{cityId}")]

        public IActionResult DeleteCity(int cityId)
        {
            //var city = _citiesModel.FirstOrDefault(c => c.Id == cityId);
            var city = _cityRepository.DeleteCity(cityId);
            if (city == false)
            {
               return NotFound();
            }
            else
            //{
            //    _citiesModel.Remove(city);
            //}
            return NoContent();
        }
    }
}


