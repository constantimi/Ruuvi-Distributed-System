using System.ComponentModel.DataAnnotations;

namespace Ruuvi.Dtos
{
    public class ConstrainCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string DeviceId { get; set; }

        [Required]
        public double TemperatureMin { get; set; }

        [Required]
        public double TemperatureMax { get; set; }

        [Required]
        public double HumidityMin { get; set; }

        [Required]
        public double HumidityMax { get; set; }

        [Required]
        public double PressureMin { get; set; }

        [Required]
        public double PressureMax { get; set; }
    }
}
