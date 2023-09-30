namespace Domain.Mapping.GlassRequestDto
{
    public class OrderLine
    {
        public string type { get; set; }
        public string No { get; set; }
        public int LineNo { get; set; }
        public decimal Quantity { get; set; }
        public string ItemCategory { get; set; }
    }
}
