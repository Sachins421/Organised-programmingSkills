using Model.Data.Models.ProductionLineRequest;

namespace Model.Data.Wrapper
{
    public class GlassRequestMessageWrapper : MessageWrapper
    {
        public GlassProductionLineRequest ProductionLine { get; set; }

        public string EventType { get; set; }
    }
}
