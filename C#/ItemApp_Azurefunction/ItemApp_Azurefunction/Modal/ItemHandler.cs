using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ItemApp_Azurefunction.ErrorHandling;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ItemApp_Azurefunction.Modal
{
    public class ItemHandler : IItemRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;   
        public ItemHandler(IMongoClient mongoClient, IMongoDatabase mongoDatabase) 
        {
            _client = mongoClient ?? throw new ArgumentNullException(nameof(mongoClient));
            _database = mongoDatabase ?? throw new ArgumentNullException(nameof(mongoDatabase)); 
        }

        public async Task Create(ProductModel action)
        {
            var collection = _database.GetCollection<ProductModel>(Environment.GetEnvironmentVariable("MongoDBCollection")); // Define your ProductModel class to adapt collection

            IndexKeysDefinition<ProductModel> indexKeys = "{ No : 1 }";
            var indexModal = new CreateIndexModel<ProductModel>(indexKeys);
            await collection.Indexes.CreateOneAsync(indexModal);
            await collection.InsertOneAsync(action);
        }

        public async Task Update(string productid, ProductModel actionRequest)
        {
            var collection = _database.GetCollection<ProductModel>(Environment.GetEnvironmentVariable("MongoDBCollection")); // Define your ProductModel class to adapt collection
            
            var filter = new FilterDefinitionBuilder<ProductModel>().Where(r => r.No == productid); // class is used to build filter definitions for MongoDB queries.

            // check if item input is valid 
            var Isitemfound = await collection.Find(x => x.No == productid).FirstOrDefaultAsync();
            if (Isitemfound == null) 
                throw new NotFoundException($"Bad Request. Item {productid} not found. try again.");

            var update = Builders<ProductModel>.Update
                .Set(product => product.ItemName ,actionRequest.ItemName);

            await collection.UpdateOneAsync(filter, update);
        }

        public async Task<List<ProductModel>> Read(string productid)
        {
            var collection = _database.GetCollection<ProductModel>(Environment.GetEnvironmentVariable("MongoDBCollection")); // Define your ProductModel class to adapt collection

            // check if item input is valid 
            var Isitemfound = await collection.Find(x => x.No == productid).FirstOrDefaultAsync();
            if (Isitemfound == null)
                throw new NotFoundException($"Bad Request. Item {productid} not found. try again.");

            var filter = new FilterDefinitionBuilder<ProductModel>().Where(r => r.No == productid); // class is used to build filter definitions for MongoDB queries.

            var ListOfItems = await collection.Find(f => f.No == productid).ToListAsync();

            return ListOfItems; 
        }

        public async Task Delete(string productid)
        {

            var collection = _database.GetCollection<ProductModel>(Environment.GetEnvironmentVariable("MongoDBCollection")); // Define your ProductModel class to adapt collection

            var filter = new FilterDefinitionBuilder<ProductModel>().Where(r => r.No == productid); // class is used to build filter definitions for MongoDB queries.

            // check if item input is valid 
            var Isitemfound = await collection.Find(x => x.No == productid).FirstOrDefaultAsync();
            if (Isitemfound == null)
                throw new NotFoundException($"Bad Request. Item {productid} not found. try again.");

            await collection.DeleteOneAsync(filter);
        }

    }
}
