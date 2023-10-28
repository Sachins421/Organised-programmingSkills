using Model.Data.Models.ManufacturerSetup;
using Model.Data.Wrapper;

namespace Model.Data.Repositries.ManufacturerSetup
{
    public interface IManufacturerSetupRepository
    {
        Task<ResponseWrapper> ProcessManufacturerSetupRequest(List<ManufacturerSetupRequestWrapper> manufacturerSetupRequestWrappers);

        Task<List<MfrSetup>> ReadManufacturerSetup();
    }
}