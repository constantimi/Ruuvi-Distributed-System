using Ruuvi.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ruuvi.Models.Data
{
    [BsonCollection("boundaries")]
    public class Boundary : Document
    {
        [BsonElement]
        public double Radius { get; set; }

        [BsonElement]
        public string Colour { get; set; }

        [BsonElement]
        public Location Location { get; set; }
    }
}
