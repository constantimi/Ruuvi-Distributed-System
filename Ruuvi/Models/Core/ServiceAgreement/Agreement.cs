﻿using System.Collections.Generic;
using Ruuvi.Models.Data;
using Ruuvi.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ruuvi.Models.Core.ServiceAgreement
{
    [BsonCollection("agreement_constrains")]
    public class Agreement : Document
    {
        [BsonElement]
        public List<Tag> Tags { get; set; }

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
