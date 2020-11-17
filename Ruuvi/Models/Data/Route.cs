using System.Collections.Generic;
using Ruuvi.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ruuvi.Models.Data
{
    [BsonCollection("routes")]
    public class Route : Document
    {
        [BsonElement]
        public List<Boundary> Points { get; set; }
    }
}