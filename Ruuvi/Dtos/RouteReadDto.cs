using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ruuvi.Models.Data;

namespace Ruuvi.Dtos
{
    public class RouteReadDto
    {        public string Id { get; set; }

        public string DeviceId { get; set; }

        public List<Boundary> Points { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}