using Model.Data.Models.Setups;
using Model.Data.Wrapper;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Repositries.Setup
{
    public class SetupRepository : ISetupRepository
    {
        private readonly IMongoRepository<SetupData> _setupData;
        public SetupRepository(IMongoRepository<SetupData> mongoRepository) 
        {
            _setupData = mongoRepository;
            
        }
        public async Task<SetupResponseWrapper> CreateSetupAsync(SetupData setupData)
        {
            var filter = Builders<SetupData>.Filter.Eq(s => s._id, setupData._id) &
                            Builders<SetupData>.Filter.Eq(s => s.Company, setupData.Company);

            var result = await _setupData.GetCollection().ReplaceOneAsync(filter, setupData, new ReplaceOptions { IsUpsert = true });

            var resultToken = new IdAndLockTocken();

            if (result != null)
            {
                var response1 = Helper.ReturnIdAndLockTocken(
                    null,
                    setupData._id,
                    setupData.Company,
                    1,
                    true,
                    false,
                    "Record inserted Successfullly!"
                    );
                var res = new SetupResponseWrapper
                {
                    IdAndLockTocken = resultToken,
                };
                
                return res;
            }

           var response = Helper.ReturnIdAndLockTocken(
                    null,
                    setupData._id,
                    setupData.Company,
                    1,
                    true,
                    false,
                    "Record insertion failed."
                    );
            var s = new SetupResponseWrapper
            {
                IdAndLockTocken = resultToken,
            };
            return s;
        }


        public async Task<SetupData> ReadSetupAsync(string id)
        {
            var filter = Builders<SetupData>.Filter.Eq(s => s._id, id);
                           

            var result = await _setupData.GetCollection().Find(filter).FirstOrDefaultAsync();

            return result;

        }
    }
}
