using Model.Data.Models.ProductionLineRequest;
using Model.Data.Wrapper;

namespace Model.Data.Repositries
{
    public interface IProductionLineRepository
    {
        Task<ResponseWrapper> ProcessUpsertProductionLineAsync(List<GlassRequestMessageWrapper> glassRequest);

        Task<GlassProductionLineRequest> GetProductionLinebyId(string id);
    }
}