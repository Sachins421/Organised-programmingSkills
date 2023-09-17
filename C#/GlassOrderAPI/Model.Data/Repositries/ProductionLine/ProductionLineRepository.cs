using Model.Data.ProductionLineRequest;
using Model.Data.Repositries;
using Model.Data.Wrapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Service.Repositries
{
    public class ProductionLineRepository : IProductionLineRepository
    {
        private readonly IMongoRepository<GlassProductionLineRequest> _glassProductionLineRequest;

        public ProductionLineRepository(IMongoRepository<GlassProductionLineRequest> glassProductionLineRequest)
        {
            _glassProductionLineRequest = glassProductionLineRequest;
        }


        public async Task<ResponseWrapper> ProcessUpsertProductionLineAsync(List<GlassRequestMessageWrapper> productionLines)
        {
            var duplicateToken = new List<IdAndLockTocken>();
            var response = new ResponseWrapper();
            var completeToken = new List<IdAndLockTocken>();
            var addProductinLine = new List<UpdateOneModel<GlassProductionLineRequest>>();
            var updateProductionLine = new List<UpdateOneModel<GlassProductionLineRequest>>();

            try 
            {
                if (productionLines.Count > 0)
                {
                    var existingRecords = Builders<GlassProductionLineRequest>.Filter.In(x => x.Id, productionLines.Where(c => !c.IsDuplicate).Select(x => x.Id));
                    var projection = Builders<GlassProductionLineRequest>.Projection.Expression(c => PrepareProductionLineProjection(c));

                    var options = new FindOptions<GlassProductionLineRequest, GlassProductionLineRequest> { Projection = projection };

                    var existingIds = await _glassProductionLineRequest.GetCollection().Find(existingRecords).Project<GlassProductionLineRequest>(projection).ToListAsync();

                    foreach (var productionLine in productionLines)
                    {
                        if (productionLine.IsDuplicate)
                        {
                            duplicateToken.Add(Helper.ReturnIdAndLockTocken(productionLine.Id, productionLine.MessageId, productionLine.EventMessageLockToken,
                                productionLine.EventDeliveryCount, productionLine.IsDuplicate, productionLine.IsDuplicate, string.Empty));
                        }
                        else
                        {
                            var correspondingRecord = existingIds.Any() ? existingIds.Where(c => c.Id == productionLine.Id
                                && c.Id.SalesCountryISO == productionLine.Id.SalesCountryISO
                                && c.Id.LineNo == productionLine.Id.LineNo
                                && c.Id.SalesChannel == productionLine.Id.SalesChannel).ToList().FirstOrDefault() : null;

                            if (correspondingRecord == null)
                            {
                                var upsertModel = new UpdateOneModel<GlassProductionLineRequest>(
                                        FilterProductionLinebyId(productionLine.Id.id, productionLine.Id.SalesChannel, productionLine.Id.SalesCountryISO, productionLine.Id.LineNo),
                                        new UpdateDefinitionBuilder<GlassProductionLineRequest>().Pipeline(PipelineDefinition<GlassProductionLineRequest, GlassProductionLineRequest>
                                        .Create(Helper.GetBsonDocument(productionLine.ProductionLine.ToBsonDocument())
                                 ))); // Update document based on the filter provided if does not exist create new one
                                      // pipeline is used to update data sequentially 

                                upsertModel.IsUpsert = true;
                                addProductinLine.Add(upsertModel);

                                completeToken.Add(Helper.ReturnIdAndLockTocken(productionLine.Id, productionLine.MessageId, productionLine.EventMessageLockToken,
                                    productionLine.EventDeliveryCount, productionLine.IsDuplicate, productionLine.IsDuplicate, string.Empty));
                            }

                            else if (correspondingRecord.Execution.TimeStamp < productionLine.ProductionLine.Execution.TimeStamp)
                            {
                                var getFilter = Builders<GlassProductionLineRequest>.Filter.Where(com => com.Id.id == productionLine.Id.id &&
                                                                                                    com.Id.LineNo == productionLine.Id.LineNo &&
                                                                                                    com.Id.SalesChannel == productionLine.Id.SalesChannel &&
                                                                                                    com.Id.SalesCountryISO == productionLine.Id.SalesCountryISO);
                                if (correspondingRecord.ArchivedExecutions == null)
                                {
                                    // Set the value:  is a MongoDB update operation that sets a field to a specified value.
                                    // indicates that the field ArchivedExecutions should be updated.
                                    // Builder class is used to create update definitions for update operations in MongoDB.
                                    updateProductionLine.Add(new UpdateOneModel<GlassProductionLineRequest>(getFilter, Builders<GlassProductionLineRequest>.Update
                                                                                                                // Had to created list type because archived execution is type of list 
                                                                                                                .Set(s => s.ArchivedExecutions, new List<Execution> { correspondingRecord.Execution })
                                                                                                                .Set(s => s.Execution, correspondingRecord.Execution)
                                                                                                                .Set(s => s.UpdatedAt, DateTime.UtcNow)));
                                }
                                else
                                {   //If the field specified in .Push is an array and the field already exists in the document,
                                    //MongoDB will add the specified values to the end of the existing array.    
                                    updateProductionLine.Add(new UpdateOneModel<GlassProductionLineRequest>(getFilter, Builders<GlassProductionLineRequest>.Update
                                            .Push(com => com.ArchivedExecutions, correspondingRecord.Execution) // list of exeution is not needed as it will add in the existing document. 
                                            .Set(com => com.Execution, productionLine.ProductionLine.Execution)
                                            .Set(com => com.UpdatedAt, DateTime.UtcNow)));
                                }
                                completeToken.Add(Helper.ReturnIdAndLockTocken(productionLine.Id, productionLine.MessageId, productionLine.EventMessageLockToken,
                                    productionLine.EventDeliveryCount, productionLine.IsDuplicate, productionLine.IsDuplicate, string.Empty));
                            }
                            else
                            {
                                completeToken.Add(Helper.ReturnIdAndLockTocken(productionLine.Id, productionLine.MessageId, productionLine.EventMessageLockToken,
                                   productionLine.EventDeliveryCount, productionLine.IsDuplicate, productionLine.IsDuplicate, "Product exist with a newer timestamp."));
                            }
                        }
                    }

                    if (addProductinLine.Any())
                    {
                        await _glassProductionLineRequest.GetCollection().BulkWriteAsync(addProductinLine);
                    }
                    if (updateProductionLine.Any())
                    {
                        await _glassProductionLineRequest.GetCollection().BulkWriteAsync(updateProductionLine);
                    }

                }
                else
                {
                    duplicateToken.AddRange(productionLines.Select(com => Helper.ReturnIdAndLockTocken(com.Id, com.MessageId, com.EventMessageLockToken,
                                   com.EventDeliveryCount, com.IsDuplicate, com.IsDuplicate, $"Product {JsonConvert.SerializeObject(com.Id)} not found")));
                }

                duplicateToken.AddRange(completeToken);
                response.idAndLockTockens = duplicateToken;
                return response;
            }
            catch(Exception e)
            {
                duplicateToken.AddRange(Helper.AbondonMsgs(productionLines,response,e.Message));
                response.idAndLockTockens = duplicateToken;
                return response;
            }
            


            //var mongoCollection = database.GetCollection<GlassRequest>(databaseSettings.collection);
            

            //var addProductionLine = new List<UpdateOneModel<ProductionLineRequest>>();

            //var filterRecord = Builders<ProductionLineRequest>.Filter.In(x => x.Id);

            //await mongoCollection.InsertOneAsync(productionline);


        }

        public async Task GetProductionLinebyId(string id)
        {
            throw new NotImplementedException();
        }

        private static GlassProductionLineRequest PrepareProductionLineProjection(GlassProductionLineRequest prodline)
        {
            return new GlassProductionLineRequest
            {
                Id = prodline.Id,
                Execution = new Execution
                {
                    GlassRequest = new Model.Data.ProductionLineRequest.GlassRequests.GlassRequest
                    {
                        BaseData = new Model.Data.ProductionLineRequest.GlassRequests.BaseData
                        {
                            GlassRequestEntryNo = prodline.Execution.GlassRequest.BaseData.GlassRequestEntryNo,
                            SalesChannelERP = prodline.Execution.GlassRequest.BaseData.SalesChannelERP,
                            BarcodePreManufacturing = prodline.Execution.GlassRequest.BaseData.BarcodePreManufacturing
                        },
                        Availabilities = prodline.Execution.GlassRequest.Availabilities,
                        Item = new Model.Data.ProductionLineRequest.GlassRequests.Item
                        {
                            ItemNo = prodline.Execution.GlassRequest.Item.ItemNo
                        }
                    },
                    TimeStamp = prodline.Execution.TimeStamp,
                    GlassRequestEntryNo = prodline.Execution.GlassRequestEntryNo
                },
            };
        }

        private static FilterDefinition<GlassProductionLineRequest> FilterProductionLinebyId(string id, string saleschannel, string saleschanneISO, string LineNo)
         => Builders<GlassProductionLineRequest>.Filter.And(
             Builders<GlassProductionLineRequest>.Filter.Eq(com => com.Id.id, id),
             Builders<GlassProductionLineRequest>.Filter.Eq(com => com.Id.LineNo, LineNo),
             Builders<GlassProductionLineRequest>.Filter.Eq(com => com.Id.SalesChannel, saleschannel),
             Builders<GlassProductionLineRequest>.Filter.Eq(com => com.Id.SalesCountryISO, saleschanneISO));
    }
}
