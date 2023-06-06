using JsonReader;
using MongoDB.Bson;
using MongoDB.Driver;
using OnlinePizzaAPI.Models;
using System.Text.Json;


namespace OnlinePizzaAPI.ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PizzaStoreDatabaseSettings DatabaseSettings = new PizzaStoreDatabaseSettings();
            var mongoclient = new MongoClient("mongodb://127.0.0.1:27017/?directConnection=true&serverSelectionTimeoutMS=2000&appName=mongosh+1.9.1");

            var mongodb = mongoclient.GetDatabase("OnlinePizzaStore");

            var _collection = mongodb.GetCollection<UserCredentials>("Credentials");

            var documents = _collection.Find(new BsonDocument()).ToList();

            Console.WriteLine("User Name /t Password");

            foreach (var document in documents)
            {
                Console.WriteLine($"{document.UserName} /t {document.Password}");
            }

            //var per = Permissions();
            Console.WriteLine(Permissions.Default(AccountType.Guest));

            Console.WriteLine(Convert.ToString((byte)Permissions.Default(AccountType.Guest), 2).PadLeft(8, '0'));

            //Grant
            Console.WriteLine(Permissions.Grant(Permission.Read, Permission.Write));

            //Revoke
            Console.WriteLine(Permissions.Revoke(Permission.Read, Permission.Read));

            //Check
            Console.WriteLine(Permissions.Check(Permission.Read, Permission.Write));


            Console.ReadLine();
        }
    }
}
