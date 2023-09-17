namespace Data.DatabaseSettings
{
    public interface IDatabaseSettings
    {
        string collection { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}