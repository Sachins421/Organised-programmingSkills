using Model.Data.Repositries;

namespace Model.Data.Wrapper
{
    public class MessageWrapper
    {
        public Id Id { get; set; }

        public string MessageId { get; set; }

        public string EventMessageLockToken { get; set; }

        public bool IsDuplicate { get; set; }

        public int EventDeliveryCount { get; set; }
    }
}
