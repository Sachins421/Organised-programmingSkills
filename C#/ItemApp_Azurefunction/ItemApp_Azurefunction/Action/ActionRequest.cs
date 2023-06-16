using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemApp_Azurefunction.Action
{
    public class ActionRequest
    {

        public string Id { get; set; }

        public string No { get; set; }

        public string ItemName { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
