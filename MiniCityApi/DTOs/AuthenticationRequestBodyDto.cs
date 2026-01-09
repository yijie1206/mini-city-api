namespace MiniCityApi.DTOs
{
    public class AuthenticationRequestBodyDto
    {
        public string? UserName { get; set; } =string.Empty;
        public string? Password { get; set; }
    }
}
