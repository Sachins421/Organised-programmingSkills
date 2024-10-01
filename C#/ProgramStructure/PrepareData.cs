namespace ProgramStructure
{
    public class PrepareData
    {

        public static List<Items> GetItems()
        {
            List<Items> items = new List<Items> // one way of defining list 
        {
            new Items { ItemCode = "SKU011", Name = "Items A", Price = 1.56M, quantity = 10},
            new Items { ItemCode = "SKU012", Name = "Items B", Price = 5.56M, quantity = 11},
            new Items { ItemCode = "SKU013", Name = "Items C", Price = 1.56M, quantity = 11},
            new Items { ItemCode = "SKU014", Name = "Items D", Price = 3.56M, quantity = 14},
            new Items { ItemCode = "SKU015", Name = "Items E", Price = 2.56M, quantity = 20}
        };
            return items;
        }
        public static List<Customers> GetCustomers()
        {
            List<Customers> customers = // second way of defining 
        [
            new Customers {Id = "Cust123", Name = "Customer 1", Address = "Address 1", PostCode = "12345", City = "Berlin", DefualtItemNo = "Item A"},
            new Customers {Id = "Cust124", Name = "Customer 3", Address = "Address 3", PostCode = "1345", City = "Berlin", DefualtItemNo = "Item A"}, 
            new Customers {Id = "Cust125", Name = "Customer 2", Address = "Address 2", PostCode = "14193", City = "Berlin", DefualtItemNo = "Item D"},
            new Customers {Id = "Cust126", Name = "Customer 4", Address = "Address 4", PostCode = "12354", City = "Berlin", DefualtItemNo = "Item C"},
            new Customers {Id = "Cust127", Name = "Customer 6", Address = "Address 6", PostCode = "4546", City = "Berlin", DefualtItemNo = "Item B"},

        ];

            return customers;

        }
    }
}