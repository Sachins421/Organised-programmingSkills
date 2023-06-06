using MongoDB.Bson;

namespace OnlinePizzaAPI.Models
{
    public class Pizza
    {
        public ObjectId _id { get; set; }
        
        public int Key { get; set; } 
        public string? Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public double price { get; set; }

    }
}
