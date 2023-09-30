using Model.Data.Models.ProductionLineRequest;
using Model.Data.Wrapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace Model.Data.Repositries
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
                    // this filter did not work so had to create seprate filter for all the fields.
                    //var existingRecords = Builders<GlassProductionLineRequest>.Filter.In(s => s.Id.id, productionLines.Where(c => !c.IsDuplicate).Select(i => i.Id.id));
                    
                    var existingRecords = new List<FilterDefinition<GlassProductionLineRequest>>();
                    existingRecords.Add(Builders<GlassProductionLineRequest>.Filter.In(s => s.Id.id, productionLines.Where(c => !c.IsDuplicate).Select(i => i.Id.id)));
                    existingRecords.Add(Builders<GlassProductionLineRequest>.Filter.In(s => s.Id.LineNo, productionLines.Where(c => !c.IsDuplicate).Select(i => i.Id.LineNo)));
                    existingRecords.Add(Builders<GlassProductionLineRequest>.Filter.In(s => s.Id.SalesChannel, productionLines.Where(c => !c.IsDuplicate).Select(i => i.Id.SalesChannel)));
                    existingRecords.Add(Builders<GlassProductionLineRequest>.Filter.In(s => s.Id.SalesCountryISO, productionLines.Where(c => !c.IsDuplicate).Select(i => i.Id.SalesCountryISO)));

                    var filter = Builders<GlassProductionLineRequest>.Filter.And(existingRecords);

                    // this too did not work landed in exception
                    //var projection = Builders<GlassProductionLineRequest>.Projection.Expression(c => PrepareProductionLineProjection(c));
                    var projection = Builders<GlassProductionLineRequest>.Projection.Expression(c => new GlassProductionLineRequest
                    {
                        Id = c.Id,
                        Execution = new Execution
                        {
                            GlassRequest = new Model.Data.Models.ProductionLineRequest.GlassRequests.GlassRequest
                            {
                                BaseData = new Model.Data.Models.ProductionLineRequest.GlassRequests.BaseData
                                {
                                    GlassRequestEntryNo = c.Execution.GlassRequest.BaseData.GlassRequestEntryNo,
                                    SalesChannelERP = c.Execution.GlassRequest.BaseData.SalesChannelERP,
                                    BarcodePreManufacturing = c.Execution.GlassRequest.BaseData.BarcodePreManufacturing
                                },
                                Availabilities = c.Execution.GlassRequest.Availabilities,
                                Item = new Model.Data.Models.ProductionLineRequest.GlassRequests.Item
                                {
                                    ItemNo = c.Execution.GlassRequest.Item.ItemNo
                                }
                            },
                            TimeStamp = c.Execution.TimeStamp,
                            GlassRequestEntryNo = c.Execution.GlassRequestEntryNo
                        },
                    });


                    var options = new FindOptions<GlassProductionLineRequest, GlassProductionLineRequest> { Projection = projection };

                    var existingIds = await _glassProductionLineRequest.GetCollection().Find(filter).Project<GlassProductionLineRequest>(projection).ToListAsync();
                    //var existingIds = await _glassProductionLineRequest.GetCollection().Find(filter).ToListAsync();
                    foreach (var productionLine in productionLines)
                    {
                        if (productionLine.IsDuplicate)
                        {
                            duplicateToken.Add(Helper.ReturnIdAndLockTocken(productionLine.Id, productionLine.MessageId, productionLine.EventMessageLockToken,
                                productionLine.EventDeliveryCount, productionLine.IsDuplicate, productionLine.IsDuplicate, string.Empty));
                        }
                        else
                        {
                            var correspondingRecord = existingIds.Any() ? existingIds.Where(c => c.Id.id == productionLine.Id.id
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

        }

        public async Task<GlassProductionLineRequest> GetProductionLinebyId(string id)
        {
            var filter = Builders<GlassProductionLineRequest>.Filter.Eq(s => s.Id.id , id);
             
            
            var glassProductionLineRequest = await _glassProductionLineRequest.GetCollection().Find(filter).FirstOrDefaultAsync();
            return glassProductionLineRequest;
            // this can also be done via Expression delgate function 
            // public ValueTask<ProductionLineRequest> ReadProductionLineByIdAsync(Expression<Func<ProductionLineRequest, bool>> matches)
            //=> _productionLineRepository.FindOneAsync(matches);
        }

        private static GlassProductionLineRequest PrepareProductionLineProjection(GlassProductionLineRequest prodline)
        {
            return new GlassProductionLineRequest
            {
                Id = prodline.Id,
                Execution = new Execution
                {
                    GlassRequest = new Model.Data.Models.ProductionLineRequest.GlassRequests.GlassRequest
                    {
                        BaseData = new Model.Data.Models.ProductionLineRequest.GlassRequests.BaseData
                        {
                            GlassRequestEntryNo = prodline.Execution.GlassRequest.BaseData.GlassRequestEntryNo,
                            SalesChannelERP = prodline.Execution.GlassRequest.BaseData.SalesChannelERP,
                            BarcodePreManufacturing = prodline.Execution.GlassRequest.BaseData.BarcodePreManufacturing
                        },
                        Availabilities = prodline.Execution.GlassRequest.Availabilities,
                        Item = new Model.Data.Models.ProductionLineRequest.GlassRequests.Item
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
