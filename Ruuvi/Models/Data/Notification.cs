using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ruuvi.Repository.Service;
using MongoDB.Bson.Serialization.Attributes;

namespace Ruuvi.Models.Data
{
    [BsonCollection("notifications")]
    public class Notification : Document
    {
        [BsonElement]
        public string Title { get; set; }

        [BsonElement]
        public string Description { get; set; }
    }
}
