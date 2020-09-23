using System.ComponentModel.DataAnnotations;

namespace Ruuvi.Dtos
{
    public class TagCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string HowTo { get;set;}
        [Required]
        public string Line { get; set;}
        [Required]
        public string Platform { get; set;}
    }
}