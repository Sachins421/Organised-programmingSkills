namespace OnlinePizzaAPI.Models
{
    public class Pizza
    {
        public int Id { get; set; } 
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public double price { get; set; }

    }
}
