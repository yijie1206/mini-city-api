using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiniCityApi.Controllers;
using MiniCityApi.DomainModel;
using MiniCityApi.Mappings;
using MiniCityApi.Model;
using MiniCityApi.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;



namespace MiniCityApi.Tests
{
    public class CityControllerTests
    {
        [Fact]
        public void GetCity_ReturnsOk_WhenCityExists()
        {

            //arrange
            var cityId = 1;

            var city = new CityModel
            {
                Id = cityId,
                Name = "Auckland",
                Description = "Test city"
            };

            var mockRepo = new Mock<ICityRepository>();
            mockRepo
                .Setup(r => r.GetCity(cityId))
                .Returns(city);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CityProfile>();
            });
            var mapper = mapperConfig.CreateMapper();


            var controller = new CityController(mockRepo.Object, mapper);

          

            //act
            var result = controller.GetCity(cityId);

            //assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            var returnedCity = Assert.IsType<CityDto>(okResult.Value);
            Assert.Equal(cityId, returnedCity.Id);//citymodel needs to be modified later to citydto
        }

        [Fact]
        public void GetCity_ReturnsNotFound_WhenCityNotExists()
        {
            //arrange
            var cityId = 10;

            //var city = new CityModel
            //{
            //    Id = cityId,
            //    Name = "Auckland",
            //    Description = "Test city"
            //};

            //var mockRepo = new Mock<ICityRepository>();
            //mockRepo
            //    .Setup(r => r.GetCity(1))
            //    .Returns(city);
            var mockRepo = new Mock<ICityRepository>();
            mockRepo
                .Setup(r => r.GetCity(1));

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CityProfile>();
            });
            var mapper = mapperConfig.CreateMapper();


            var controller = new CityController(mockRepo.Object, mapper);

            //act
            var result = controller.GetCity(cityId);

            //assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
        }

    }
}
