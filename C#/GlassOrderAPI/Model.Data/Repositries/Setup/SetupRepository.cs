using Model.Data.Models.Setups;
using Model.Data.Wrapper;
using MongoDB.Driver;
using System.Linq.Expressions;

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
            var filter = Builders<SetupData>.Filter.Eq(s => s.id, setupData.id) &
                            Builders<SetupData>.Filter.Eq(s => s.Company, setupData.Company);

            var result = await _setupData.GetCollection().ReplaceOneAsync(filter, setupData, new ReplaceOptions { IsUpsert = true });

            var resultToken = new IdAndLockTocken();

            if (result != null)
            {
                var response1 = Helper.ReturnIdAndLockTocken(
                    null,
                    setupData.id,
                    setupData.Company,
                    1,
                    true,
                    false,
                    "Record inserted Successfullly!"
                    );
                var res = new SetupResponseWrapper
                {
                    IdAndLockTocken = response1,
                };
                
                return res;
            }

           var response = Helper.ReturnIdAndLockTocken(
                    null,
                    setupData.id,
                    setupData.Company,
                    1,
                    true,
                    false,
                    "Record insertion failed."
                    );
            var s = new SetupResponseWrapper
            {
                IdAndLockTocken = response,
            };
            return s;
        }


        public async Task<SetupData> ReadSetupAsync()
        {
            Expression<Func<SetupData,bool>> expression = p => !string.IsNullOrEmpty(p.id);

            var result = await _setupData.GetCollection().Find(expression).FirstOrDefaultAsync();

            return result;

        }
    }
}
