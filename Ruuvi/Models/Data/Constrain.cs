﻿using Ruuvi.Repository;
using MongoDB.Bson.Serialization.Attributes;

namespace Ruuvi.Models.Data
{
    [BsonCollection("constrains")]
    public class Constrain : Document
    {
        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string Description { get; set; }

        [BsonElement]
        public double TemperatureMin { get; set; }

        [BsonElement]
        public double TemperatureMax { get; set; }

        [BsonElement]
        public double HumidityMin { get; set; }

        [BsonElement]
        public double HumidityMax { get; set; }

        [BsonElement]
        public double PressureMin { get; set; }

        [BsonElement]
        public double PressureMax { get; set; }
    }
}
