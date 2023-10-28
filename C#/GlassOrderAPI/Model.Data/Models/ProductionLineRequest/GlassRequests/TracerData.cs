﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.ProductionLineRequest.GlassRequests
{
    public class TracerData
    {
        [BsonElement(nameof(EntryNo))]
        public int EntryNo { get; set; }

        [BsonElement(nameof(DistanceBetweenLenses))]
        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)] // This provides a precise decimal representation, can't be use double, 
        public decimal DistanceBetweenLenses { get; set; }
        public string GlassTracingData { get; set; }
    }
}