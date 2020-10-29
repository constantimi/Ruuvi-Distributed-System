using System.ComponentModel.DataAnnotations;

namespace Ruuvi.Dtos
{
    public class NotificationCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string DeviceId { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
