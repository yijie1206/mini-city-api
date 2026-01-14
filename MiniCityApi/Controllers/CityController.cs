using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCityApi.DomainModel;
using MiniCityApi.DTOs;
using MiniCityApi.Model;
using MiniCityApi.Repositories;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;

        public CityController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }



        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            var city = _cityRepository.GetCities();

            var cityDto = _mapper.Map<IEnumerable<CityDto>>(city);
            return Ok(cityDto);
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
                var cityDto = _mapper.Map<CityDto>(city);
                return Ok(cityDto);
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
            //var cityModel = new CityModel
            //{
            //    Name = createCityDto.Name,
            //    Description = createCityDto.Description,
            //};
            var cityModel = _mapper.Map<CityModel>(createCityDto);

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
            var cityDto = _mapper.Map<CityDto>(city);
            return CreatedAtAction
                (
                "GetCity",
                new { cityId = city.Id },
                cityDto
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

            var getExistingCity = _cityRepository.GetCity(cityId);        
                
            if (getExistingCity == null)
            {
                return NotFound();
            }

            var cityModel = _mapper.Map(updateCityDto, getExistingCity);

            //manual map is replace by automapper
            //var cityModel = new CityModel
            //{
            //    Id = cityId,
            //    Name = updateCityDto.Name,
            //    Description = updateCityDto.Description,
            //};


            //save
             _cityRepository.UpdateCity(cityModel);
            
            //if (!city)
            //{
            //    return NotFound();
            //}
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



