using Microsoft.VisualBasic;
using Model.Data.Models.ManufacturerSetup;
using Model.Data.Models.Setups;
using Model.Data.Wrapper;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Model.Data.Repositries.ManufacturerSetup
{
    public class ManufacturerSetupRepository : IManufacturerSetupRepository
    {
        private IMongoRepository<MfrSetup> _mongoRepository;

        public ManufacturerSetupRepository(IMongoRepository<MfrSetup> mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }

        public async Task<ResponseWrapper> ProcessManufacturerSetupRequest(List<ManufacturerSetupRequestWrapper> manufacturerSetupRequestWrappers)
        {
            var response = new ResponseWrapper();
            var duplicateToken = new List<IdAndLockTocken>();

            try
            {

                if (manufacturerSetupRequestWrappers.Count > 0)
                {
                    var upsertRecord = new List<UpdateOneModel<MfrSetup>>();
                    
                    var completeToken = new List<IdAndLockTocken>();
                    List<LogError> errorList = new List<LogError>();

                    foreach (var Manufacturer in manufacturerSetupRequestWrappers)
                    {
                        var filterRecords = Builders<MfrSetup>.Filter.In(s => s.Id, Manufacturer.Manufacturer.Select(x => x.Id));
                        var getRecords = await _mongoRepository.GetCollection().FindAsync(filterRecords); // ToListAync does not work here
                        var getExistingRecords = getRecords.ToListAsync().Result; // Result is to block asynchronous operation but used here to remove task variable from getExistingRecords result

                        var recordsWithNoEmtyIds = Manufacturer.Manufacturer.Where(msg => (msg.Id.id != "") && ((msg.Id.Company != ""))); // used where becoz second Manufacturer var is list type

                        //var getNotDuplicateRecords = recordsWithNoEmtyIds.GroupBy(s => new {s.Id.id, s.Id.Company}).Select(s => s.First()).ToList();

                        foreach(var item in recordsWithNoEmtyIds)
                        {
                            if (getExistingRecords.Any(msg => (msg.Id.id == item.Id.id) && (msg.Id.Company == item.Id.Company) && (msg.TimeStamp <= Manufacturer.TimeStamp))) // parent time stamp of the message
                            {
                                var filters = Builders<MfrSetup>.Filter.Eq(x => x.Id , item.Id); // takes only parameter else add with & operator

                                var update = Builders<MfrSetup>.Update.Set(s => s.BaseData, item.BaseData)
                                    .Set(s => s.ServicePrices, item.ServicePrices)
                                    .Set(s => s.manGlassPackageMappings, item.manGlassPackageMappings)
                                    .Set(s => s.manGlassCodeMappings, item.manGlassCodeMappings)
                                    .Set(s => s.AutoselectFilterChecks, item.AutoselectFilterChecks)
                                    .Set(s => s.DecisionMapping, item.DecisionMapping)
                                    .Set(s => s.TimeStamp, Manufacturer.TimeStamp)
                                    .Set(s => s.MessageID, Manufacturer.MessageId)
                                    .SetOnInsert(s => s.CreatedAt, DateTime.UtcNow);
                              
                                upsertRecord.Add(
                                    new UpdateOneModel<MfrSetup>(filters,update)
                                    {
                                        IsUpsert = true
                                    });

                            }
                            else
                            {
                                errorList.Add(new LogError(Manufacturer.TimeStamp.ToString(), $"{item.Id.id} and {item.Id.Company}"));
                            }

                        }
                        if (errorList.Count > 0)
                        {
                            duplicateToken.Add(
                                new IdAndLockTocken
                                {
                                    MessageId = Manufacturer.TimeStamp.ToString(),
                                    LockToken = Manufacturer.EventMessageLockToken,
                                    DeliveryCount = Manufacturer.EventDeliveryCount,
                                    Reason = JsonConvert.SerializeObject(errorList),
                                    IsDuplicate = false,
                                    Success = false,
                                }); 
                        }
                        else
                        {
                            duplicateToken.Add(
                                new IdAndLockTocken
                                {
                                    MessageId = Manufacturer.TimeStamp.ToString(),
                                    LockToken = Manufacturer.EventMessageLockToken,
                                    DeliveryCount = Manufacturer.EventDeliveryCount,
                                    IsDuplicate = false,
                                    Success = true,
                                });

                        }  
                        
                    }
                 
                   if (upsertRecord.Count > 0)
                    {
                        await _mongoRepository.GetCollection().BulkWriteAsync(upsertRecord);
                    }
                }
                else
                {
                    duplicateToken.AddRange(manufacturerSetupRequestWrappers.Select(msg => new IdAndLockTocken
                    {
                        MessageId = msg.MessageId,
                        LockToken = msg.EventMessageLockToken,
                        DeliveryCount = msg.EventDeliveryCount,
                        Reason = $"Manufacturer "+JsonConvert.SerializeObject(msg.MessageId)+" not found.",
                        IsDuplicate = false,
                        Success = false,

                    }));
                }
                response.idAndLockTockens = duplicateToken;
                return response;
            }
            catch (Exception ex)
            {
                duplicateToken.AddRange(manufacturerSetupRequestWrappers.Select(msg => new IdAndLockTocken
                {
                    MessageId = msg.MessageId,
                    LockToken = msg.EventMessageLockToken,
                    DeliveryCount = msg.EventDeliveryCount,
                    Reason = JsonConvert.SerializeObject(ex.Message),
                    IsDuplicate = false,
                    Success = false,

                }));
                response.idAndLockTockens = duplicateToken;
                return response;

            }

        }


        public Task<List<MfrSetup>> ReadManufacturerSetup()
        {
            return new List<MfrSetup>;
        }
    }
}
