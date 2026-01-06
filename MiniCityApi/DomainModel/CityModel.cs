namespace MiniCityApi.DomainModel
{
    public class CityModel
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string ? Description { get; set; }

        public int CityScore { get; set; }
    }
}
