﻿using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace Ruuvi.Models
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        [MaxLength(250)]
        public string DeviceId { get; set; }
    }
}
