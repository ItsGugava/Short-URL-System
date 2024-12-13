using System.ComponentModel.DataAnnotations;

namespace Short_URL_System.Dtos
{
    public class GenerateURLRequestDto
    {
        [Required]
        [Url]
        public string URL { get; set; }
    }
}
