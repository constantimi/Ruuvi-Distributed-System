﻿using System;
using System.Collections.Generic;
using Ruuvi.Models.Data;

namespace Ruuvi.Dtos.Core
{
    public class AgreementReadDto
    {
        public string Id { get; set; }

        public List<Tag> Tags { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double TemperatureMin { get; set; }

        public double TemperatureMax { get; set; }

        public double HumidityMin { get; set; }

        public double HumidityMax { get; set; }

        public double PressureMin { get; set; }

        public double PressureMax { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
