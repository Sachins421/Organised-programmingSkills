using Model.Data.Wrapper;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Data.Repositries
{
    public static class Helper
    {
        public static IdAndLockTocken ReturnIdAndLockTocken(Id Id, string messageId, string lockToken, int deliveryCount, bool success, bool isDuplicate, string reason)
        {
            return new IdAndLockTocken
            {
                Id = Id,
                MessageId = messageId,
                LockToken = lockToken,
                DeliveryCount = deliveryCount,
                Success = success,
                IsDuplicate = isDuplicate,
                Reason = reason

            };
        }

        public static List<IdAndLockTocken> AbondonMsgs<T>(List<T> t, ResponseWrapper response, string msgs) where T : MessageWrapper // can be different class
        {
            var abondonMsgs = new List<IdAndLockTocken>();
            abondonMsgs.AddRange(t.Select(msg => new IdAndLockTocken
            {
                Id = msg.Id,
                MessageId = msg.MessageId,
                LockToken =msg.EventMessageLockToken,
                IsDuplicate = msg.IsDuplicate,
                DeliveryCount = msg.EventDeliveryCount,
                Reason = msgs
            }));
            response.idAndLockTockens = abondonMsgs;
            return abondonMsgs;
        }
        public static BsonDocument GetBsonDocument(BsonDocument document)
        => new BsonDocument("$set",document); // convet document to bsondocument, $set update document partially
    }
}
