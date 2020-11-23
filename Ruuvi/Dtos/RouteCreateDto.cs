using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ruuvi.Models.Data;

namespace Ruuvi.Dtos
{
    public class RouteCreateDto
    {
        [MaxLength(250)]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DeviceId { get; set; }

        [Required]
        public Boundary[] Points { get; set; }
    }
}