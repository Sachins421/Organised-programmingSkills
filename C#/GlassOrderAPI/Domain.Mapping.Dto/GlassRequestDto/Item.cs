using Data.Enums;

namespace Domain.Mapping.GlassRequestDto
{
    public class Item
    {
        public string ItemNo { get; set; }

        public string Description { get; set; }
        public string ItemCategory { get; set; }

        public string PhysicalFrameType { get; set; }

        public string FrontMaterial { get; set; }

        public string ManufactureMethod { get; set; }

        public string Glazable { get; set; }

        public decimal EdgeThickness { get; set; }

        public Aspheric Aspheric { get; set; }

        public decimal FrontCurve { get; set; }
        public decimal GlassWidth { get; set; }
        public decimal BarWidth { get; set; }
    }
}
