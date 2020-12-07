using System.Collections.Generic;
using Ruuvi.Models.Data;
using Ruuvi.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ruuvi.Models.Core
{
    [BsonCollection("geometric_constrains")]
    public class Route : Document
    {
        [BsonElement]
        public List<string> Devices { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string Description { get; set; }

        [BsonElement]
        public List<Boundary> Points { get; set; }
    }
}
