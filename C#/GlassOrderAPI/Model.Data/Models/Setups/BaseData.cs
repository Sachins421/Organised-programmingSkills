using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class BaseData
    {
        [BsonElement("OutsourcedProductionEnabled")]
        public bool OutsourcedProductionEnabled { get; set; }
        [BsonElement("AutoGlassSelectionActivated")]
        public bool AutoGlassSelectionActivated { get; set; }
        [BsonElement("SkipOrdershavingWrshCmt")]
        public bool SkipOrdershavingWrshCmt { get; set; }
        [BsonElement("FirstChoiceARCode")]
        public int FirstChoiceARCode { get; set; }
        [BsonElement("SecondChoiceARCode")]
        public int SecondChoiceARCode { get; set; }

    }
}
