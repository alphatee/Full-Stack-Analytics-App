using TripInfo.API.Entities;

namespace TripInfo.API.Services.TripInfoServices;

public interface ITripInfoService
{
    public Task<Customer> GetCustomerWithHighestTipAsync();
    public Task<IEnumerable<MetaData>> GetSumOfTipsByStoreName();
    public Task<IEnumerable<MetaData>> GetSumOfTipsByCity();
    public Task<IEnumerable<MetaData>> GetSumOfTipsByZip();
    public Task<IEnumerable<MetaData>> GetSumOfTipsByMonth();
}
