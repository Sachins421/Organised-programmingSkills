using Model.Data.Models.Setups;
using Model.Data.Wrapper;

namespace Model.Data.Repositries.Setup
{
    public interface ISetupRepository
    {
        Task<SetupResponseWrapper> CreateSetupAsync(SetupData setupData);
        Task<SetupData> ReadSetupAsync();
    }
}