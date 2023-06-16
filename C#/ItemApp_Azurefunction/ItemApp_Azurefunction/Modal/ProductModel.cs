using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.Modal
{
    public class ProductModel
    {
        [BsonId]
        public string Id { get; set; }

        public string No { get; set; }

        [BsonElement("itemName")]
        public string ItemName { get; set; }

        [BsonElement("quantity")]
        public string Quantity { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }
    }
}
