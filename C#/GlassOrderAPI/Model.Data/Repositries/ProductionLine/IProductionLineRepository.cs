using Model.Data.Wrapper;

namespace Service.Repositries
{
    public interface IProductionLineRepository
    {
        Task<ResponseWrapper> ProcessUpsertProductionLineAsync(List<GlassRequestMessageWrapper> glassRequest);

        Task GetProductionLinebyId(string id);
    }
}