using Data.Enums;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Models.Setups
{
    public class Combinations
    {
        [BsonElement("Disabled")]
        public bool Disabled { get; set; }
        [BsonElement("GlassGroupCode")]
        public string GlassGroupCode { get; set; }
        [BsonElement("ParameterNo")]
        public int ParameterNo { get; set; }
        [BsonElement("GlassType")]
        public GlassType GlassType { get; set; }
        [BsonElement("Tinged")]
        public bool Tinged { get; set; }
        [BsonElement("PhotoTropic")]
        public bool PhotoTropic { get; set; }
        [BsonElement("Polarized")]
        public bool Polarized { get; set; }
        [BsonElement("SingleVision")]
        public bool SingleVision { get; set; }
        [BsonElement("OfficeGlass")]
        public bool OfficeGlass { get; set; }
        [BsonElement("BlueFilter")]
        public bool BlueFilter { get; set; }
        [BsonElement("Multifocal")]
        public bool MultiFocal { get; set; }
        [BsonElement("StandardTinge")]
        public bool StandardTinge { get; set; }
        [BsonElement("Gradient")]
        public bool Gradient { get; set; }
        [BsonElement("Filter")]
        public bool Filter { get; set; }

        [BsonElement("Mirrored")]
        public bool Mirrored { get; set; }
        [BsonElement("FieldofVision")]
        public FieldofVision fieldofVision { get; set; }
        [BsonElement("AutoSelectionEanbled")]
        public bool AutoSelectionEnabled { get; set; }
        [BsonElement("Priorities")]
        public List<Priorities> Priorities { get; set; }
    }
}
