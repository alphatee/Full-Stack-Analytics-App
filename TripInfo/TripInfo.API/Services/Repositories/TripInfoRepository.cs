using Microsoft.EntityFrameworkCore; // ToListAsync()
using TripInfo.API.DbContexts; // _context
using TripInfo.API.Entities;

namespace TripInfo.API.Services.Repositories;

public class TripInfoRepository : ITripInfoRepository
{
    private readonly TripInfoContext _context;

    public TripInfoRepository(TripInfoContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Customer>> GetCustomersForTripAsync(
        int tripId)
    {
        return await _context.Customers
            .Where(c => c.TripId == tripId).ToListAsync();
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<IEnumerable<MetaData>> GetMetaDataListAsync()
    {
        return await _context.MetaData.ToListAsync();
    }

    public async Task<bool> TripExistsAsync(int tripId)
    {
        return await _context.Trips.AnyAsync(t => t.Id == tripId);
    }

    public async Task<Customer?> GetCustomerForTripAsync(
        int tripId,
        int customerId)
    {
        return await _context.Customers
            .Where(c => c.TripId == tripId && c.Id == customerId)
            .FirstOrDefaultAsync();
    }

    public async Task<Trip?> GetTripAsync(
        int tripId,
        bool includeCustomer)
    {
        if (includeCustomer)
        {
            return await _context.Trips.Include(t => t.Customers)
                .Where(t => t.Id == tripId).FirstOrDefaultAsync();
        }

        return await _context.Trips
            .Where(t => t.Id == tripId).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Trip>> GetTripsAsync()
    {
        return await _context.Trips.OrderBy(t => t.StoreName).ToListAsync(); // OrderBy() is Linq at work.
    }

    public async Task<bool> CityNameMatchesTripId(string? cityName, int tripId)
    {
        return await _context.Trips.AnyAsync(t => t.Id == tripId && t.City == cityName);
    }

    public async Task<(IEnumerable<Trip>, PaginationMetadata)> GetTripsAsync( // tuple. a language feature that allows us to return multiple values from a method.
        string? name,
        string? searchQuery,
        int pageNumber,
        int pageSize)
    {
        // collection to start from
        var collection = _context.Trips as IQueryable<Trip>; // cast the DbSet<Trip> to IQueryable<Trip>, we write the code like this for "deferred execution" of the query.

        // add filter first before the search
        if (!string.IsNullOrWhiteSpace(name))
        {
            name = name.Trim();
            collection = collection.Where(t => t.StoreName == name);
        }

        // implement the search query
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            searchQuery = searchQuery.Trim();
            collection = collection.Where(t => t.StoreName.Contains(searchQuery) // I can add OR || statements here if I want to search by multiple fields.
            || t.Street != null && t.Street.Contains(searchQuery));
        }

        var totalItemCount = await collection.CountAsync(); // this is an IO call, so we use async

        var paginationMetadata = new PaginationMetadata(
            totalItemCount, pageSize, pageNumber); // this is a constructor call

        var collectionToReturn = await collection.OrderBy(t => t.StoreName)
            .Skip(pageSize * (pageNumber - 1)) // skip the first 5 items on the first page, then skip the next 5 items on the second page, etc.
            .Take(pageSize) // take the next 5 items after skipping the first 5 items.
            .ToListAsync();

        return (collectionToReturn, paginationMetadata);
    }

    public async Task<(IEnumerable<MetaData>, PaginationMetadata)> GetMetaDataListAsync( // tuple. a language feature that allows us to return multiple values from a method.
        string? name,
        string? searchQuery,
        int pageNumber,
        int pageSize)
    {
        // collection to start from
        var collection = _context.MetaData as IQueryable<MetaData>; // cast the DbSet<MetaData> to IQueryable<MetaData>, we write the code like this for "deferred execution" of the query.

        // add filter first before the search
        if (!string.IsNullOrWhiteSpace(name))
        {
            name = name.Trim();
            collection = collection.Where(m => m.StoreName == name);
        }

        // implement the search query
        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            searchQuery = searchQuery.Trim();
            collection = collection.Where(t => t.StoreName.Contains(searchQuery) // I can add OR || statements here if I want to search by multiple fields.
            || t.Street != null && t.Street.Contains(searchQuery));
        }

        var totalItemCount = await collection.CountAsync(); // this is an IO call, so we use async

        var paginationMetadata = new PaginationMetadata(
            totalItemCount, pageSize, pageNumber); // this is a constructor call

        var collectionToReturn = await collection.OrderBy(t => t.StoreName)
            .Skip(pageSize * (pageNumber - 1)) // skip the first 5 items on the first page, then skip the next 5 items on the second page, etc.
            .Take(pageSize) // take the next 5 items after skipping the first 5 items.
            .ToListAsync();

        return (collectionToReturn, paginationMetadata);
    }

    public async Task AddCustomerForTripAsync(
        int tripId,
        Customer customer)
    {
        var trip = await GetTripAsync(tripId, false); // false means we do not need to load the customers for the trip because the client is adding a new one.
        if (trip != null)
        {
            // this statement adds the customer to the in memory context but does not persist it to the database. Not an IO Call.
            trip.Customers.Add(customer); // this will make sure that the FK is set to the tripId when persisting.
        }
    }

    public void DeleteCustomer(Customer customer)
    {
        _context.Customers.Remove(customer); // this statement removes the customer from the in memory context but does not persist it to the database. Not an IO Call.
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0; // returns true if the number of changes saved is greater than or equal to 0.
    }
}
