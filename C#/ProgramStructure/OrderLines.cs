namespace ProgramStructure
{
    public class OrderLines
    {
        public string Id { get; set; } = "";
        public int LineNo { get; set; }
        public string Item { get; set; } = "";
        public int Quantity {get; set;}
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }


    }
    
}