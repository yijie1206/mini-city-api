
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniCityApi.Services;
using MiniCityApi.DomainModel;


namespace MiniCityApi.Tests
{
    public class FakeAuthenticationService : IAuthenticationService
    {
        private string fakeUserName = "aa";
        private string fakePassword = "123";

        public CityInfoUser? ValidateCredentials(string? UserName, string? Password)
        {
            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
            {
                return null;
            }

            if (UserName != fakeUserName || Password != fakePassword)
            {
                return null;
            }
            return new CityInfoUser
            {
                UserId = 1,
                UserName = UserName// UserName instad of "aa" better
            };
        }
    }
}
