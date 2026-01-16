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
            var city = _cityRepository.GetCity(cityId);
            if (city == null)
            {
                return NotFound();
            }
            var cityDto = _mapper.Map<CityDto>(city);
            return Ok(cityDto);

        }


        [HttpPost]
        public ActionResult<CityDto> CreateCity([FromBody] CreateCityDto createCityDto)
        {
            //validate input
            if (string.IsNullOrWhiteSpace(createCityDto.Name))
            {
                return BadRequest("City name is required.");
            }
            var cityModel = _mapper.Map<CityModel>(createCityDto);
            var city = _cityRepository.AddCity(cityModel);
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
            _cityRepository.UpdateCity(cityModel); //save         
            return NoContent();
        }



        [HttpDelete("{cityId}")]
        public IActionResult DeleteCity(int cityId)
        {
            var city = _cityRepository.DeleteCity(cityId);
            if (city == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}



