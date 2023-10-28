﻿using Model.Data.Repositries;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public abstract class DocumentSetup : IDocument
    {
        [BsonId, BsonElement("_id")]
        public string id { get; set; }

        [BsonElement("Company")]
        public string Company { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; }
        [BsonElement("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }
        Id IDocument.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

   /* public class setupId
    {
        [BsonElement(nameof(id))]
        [JsonProperty(PropertyName = "_id")]
        public string id { get; set; }

        [BsonElement(nameof(Company))]
        public string Company { get; set; }
    }*/
}