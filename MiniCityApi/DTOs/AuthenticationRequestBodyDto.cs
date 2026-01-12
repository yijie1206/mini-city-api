using System.ComponentModel.DataAnnotations;

namespace MiniCityApi.DTOs
{
    public class AuthenticationRequestBodyDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
