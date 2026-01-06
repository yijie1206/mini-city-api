using System.ComponentModel.DataAnnotations;

namespace MiniCityApi.DTOs
{
    public class CreateCityDto
    {
        [Required]
        [MinLength (1)]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
