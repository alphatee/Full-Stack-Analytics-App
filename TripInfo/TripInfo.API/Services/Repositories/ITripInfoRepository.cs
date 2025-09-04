using TripInfo.API.Entities;

namespace TripInfo.API.Services.Repositories;

public interface ITripInfoRepository
{
    Task<IEnumerable<Trip>> GetTripsAsync();
    Task<(IEnumerable<Trip>, PaginationMetadata)> GetTripsAsync(
        string? name,
        string? searchQuery,
        int pageNumber,
        int pageSize);
    Task<Trip?> GetTripAsync(
        int tripId,
        bool includeCustomer);
    Task<bool> TripExistsAsync(int tripId);
    Task<IEnumerable<Customer>> GetCustomersForTripAsync(int tripId);
    Task<IEnumerable<Customer>> GetCustomersAsync();
    Task<IEnumerable<MetaData>> GetMetaDataListAsync();
    Task<(IEnumerable<MetaData>, PaginationMetadata)> GetMetaDataListAsync(
        string? name,
        string? searchQuery,
        int pageNumber,
        int pageSize);
    Task<Customer?> GetCustomerForTripAsync(
        int tripId,
        int customerId);
    Task AddCustomerForTripAsync(
        int tripId,
        Customer customer); // we call " GetTripAsync " method to get the trip, and is an IO method, so we use async
    void DeleteCustomer(Customer customer); // deleting is an in memory operation, and not an IO operation. async does not make sense here
    Task<bool> CityNameMatchesTripId(string? cityName, int tripId);
    Task<bool> SaveChangesAsync();
}
