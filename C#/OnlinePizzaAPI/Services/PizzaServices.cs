using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OnlinePizzaAPI.Models;

namespace OnlinePizzaAPI.Services
{
    public class PizzaServices
    {
        private readonly IMongoCollection<Pizza> mongoCollection;

        public PizzaServices(IOptions<PizzaStoreDatabaseSettings> DatabaseSettings) 
        {

            var mongoclient = new MongoClient(DatabaseSettings.Value.connectionString);
                
            var mongodb = mongoclient.GetDatabase(DatabaseSettings.Value.databaseName);

            mongoCollection = mongodb.GetCollection<Pizza>(DatabaseSettings.Value.PizzaCollectionName);
            //pizzas = new List<Pizza>
            //{
            //    new Pizza { Id = 1 , Name = "Classic Italian", IsGlutenFree = true},
            //    new Pizza { Id = 2 , Name = "Classic Veggie", IsGlutenFree = true},
            //    new Pizza { Id = 3 , Name = "Mozorilla", IsGlutenFree = true}
            //};
        }

        public async Task<List<Pizza>> GetallAsync() => await mongoCollection.Find(_=> true).ToListAsync();

        public async Task<Pizza?> GetAsync(int id) => await mongoCollection.Find(x =>x.Key == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Pizza pizza)
        {
            await mongoCollection.InsertOneAsync(pizza);
        }

        public async Task UpdateAsync(int id, Pizza pizza)
        {
            await mongoCollection.ReplaceOneAsync(p => p.Key == id, pizza);
          
        }

        public async Task RemoveAsync(int id)
        {
            await mongoCollection.DeleteOneAsync(p => p.Key == id);
        }

        //public static List<Pizza> Getall() => pizzas;

        //public static Pizza? Get(int id) => pizzas.FirstOrDefault(p => p.Id == id); 

        //public static void add(Pizza pizza) 
        //{
        //    pizza.Id = nextId++;
        //    pizzas.Add(pizza);
        //}

        //public static void Delete(int id)
        //{
        //    var pizza = Get(id);
        //    if (pizza is null)
        //        return;

        //    pizzas.Remove(pizza);
        //}

        //public static void Update(Pizza pizza)
        //{
        //    var index = pizzas.FindIndex(p => p.Id == pizza.Id);
        //    if (index == -1)
        //        return;

        //    pizzas[index] = pizza;
        //}
    }
}
