using Ruuvi.Models.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ruuvi.Models.Core
{
    public class Boundary
    {
        [BsonElement]
        public double Radius { get; set; }

        [BsonElement]
        public string Colour { get; set; }

        [BsonElement]
        public Location Location { get; set; }
    }
}
