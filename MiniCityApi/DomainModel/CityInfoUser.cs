namespace MiniCityApi.DomainModel
{
    public class CityInfoUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }=string.Empty;
        public string City { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

    }
}
