namespace ProgramStructure
{
    public class Orders
    {
        public string Id { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public string CustomerAddress { get; set; } = "";
        public DateTimeOffset OrderDate { get; set; } 
        public string Comment { get; set; } = "";
        public List<OrderLines> orderLines { get; set; } // nullabe can also be fixed by required 
    }
}