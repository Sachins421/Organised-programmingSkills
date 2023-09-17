using Data.Enums;

namespace Domain.Mapping.Dto
{
    public class BaseData
    {
        public string BarcodePreManufacturing { get; set; }

        public string GlassManufacturerVendorNo { get; set; }

        public ManufactureMethod ManufactureMethod { get; set; }
        public decimal FreeGlassThickness { get; set; }

        public bool RepairShop { get; set; }
        public int GlassRequestEntryNo { get; set; }
        public bool HasSpecialInvReference { get; set; }
        public string ShippingAgent { get; set; }
        public bool ShopInShop { get; set; }

        public bool? IsNordicsOrder { get; set; }
        public ManufactureMethod? FinalSelectedManufactureMethod { get; set; }
    }

}
