using Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Data.Data
{
    public class BaseData
    {
        [BsonElement(nameof(BarcodePreManufacturing))]
        public string BarcodePreManufacturing { get; set; }

        [BsonElement(nameof(GlassManufacturerVendorNo))]
        public string GlassManufacturerVendorNo { get; set; }

        [BsonElement(nameof(ManufactureMethod))]
        public ManufactureMethod ManufactureMethod { get; set; }

        [BsonElement(nameof(FreeGlassThickness))]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public decimal FreeGlassThickness { get; set; }

        [BsonElement(nameof(RepairShop))]
        public bool RepairShop { get; set; }

        [BsonElement(nameof(Company))]
        public string Company { get; set; }

        [BsonElement(nameof(SalesLanguage))]
        public string SalesLanguage { get; set; }

        [BsonElement(nameof(SalesChannelERP))]
        public string SalesChannelERP { get; set; }

        [BsonElement(nameof(GlassRequestEntryNo))]
        public int GlassRequestEntryNo { get; set; }

        [BsonElement(nameof(HasSpecialInvReference))]
        public bool HasSpecialInvReference { get; set; }

        [BsonElement(nameof(ShippingAgent))]
        public string ShippingAgent { get; set; }

        [BsonElement(nameof(ShopInShop))]
        public bool ShopInShop { get; set; }

        [BsonElement(nameof(IsNordicsOrder))]
        public bool? IsNordicsOrder { get; set; }

        [BsonElement(nameof(FinalSelectedManufactureMethod))]
        public ManufactureMethod? FinalSelectedManufactureMethod { get; set; }
    }
}
