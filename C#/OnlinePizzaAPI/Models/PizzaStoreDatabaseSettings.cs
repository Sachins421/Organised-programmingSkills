namespace OnlinePizzaAPI.Models
{
    public class PizzaStoreDatabaseSettings
    {
        public string? connectionString { get; set; } = null;
        public string? databaseName { get; set; } = null;
        public string? PizzaCollectionName { get; set; } = null;
        public string? Credentials { get; set; } = null;
    }
}
