using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiniCityApi.Controllers;
using MiniCityApi.DomainModel;
using MiniCityApi.DTOs;
using MiniCityApi.Repositories;
using MiniCityApi.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MiniCityApi.Tests
{
    public class AuthenticationControllerTests
    {

        [Fact]
        public void PostAuth_ReturnsOk_WhenAuthExists()
        {
            //arrange
            var fakeUserName = "aa";
            var fakePassword = "123";

            //act
            //Fake auth service
            var fakeAuthenticationService = new FakeAuthenticationService();

            //In-memory config data
            var configValues = new Dictionary<string, string>
            {
                ["Authentication:SecretForKey"] = "9f4c2e7a1b8d4a6e90c3f2a5d7b8e1c4",
                ["Authentication:Issuer"] = "test-issuer",
                ["Authentication:Audience"] = "test-audience"
            };
            //ConfigurationBuilder usage
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddInMemoryCollection(configValues);
            var fakeConfigs = configBuilder.Build();

            //Controller construction
            var authController = new AuthenticationController(fakeAuthenticationService,
            fakeConfigs);

            var fakeAuthenticationRequestBody = new AuthenticationRequestBodyDto
            {

                UserName = fakeUserName,
                Password = fakePassword
            };

            //assert
            var result = authController.Login(fakeAuthenticationRequestBody);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.NotNull(okResult.Value);//Assert payload exists


        }


    }
}







