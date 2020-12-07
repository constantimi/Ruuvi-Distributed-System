using System.ComponentModel.DataAnnotations;
using Ruuvi.Repository;
using MongoDB.Bson.Serialization.Attributes;

namespace Ruuvi.Models.Data
{
    [BsonCollection("notifications")]
    public class Notification : Document
    {
        [MaxLength(250)]
        public string DeviceId { get; set; }

        [BsonElement]
        public string Title { get; set; }

        [BsonElement]
        public string Description { get; set; }
    }
}
