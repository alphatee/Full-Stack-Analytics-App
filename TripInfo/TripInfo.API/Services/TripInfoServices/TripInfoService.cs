using System.Globalization;
using TripInfo.API.Entities;
using TripInfo.API.Services.Repositories;

namespace TripInfo.API.Services.TripInfoServices;

public class TripInfoService : ITripInfoService
{
    private readonly ITripInfoRepository _tripInfoRepository;

    public TripInfoService(ITripInfoRepository tripInfoRepository)
    {
        _tripInfoRepository = tripInfoRepository ??
            throw new ArgumentNullException(nameof(tripInfoRepository));
    }

    public async Task<Customer> GetCustomerWithHighestTipAsync()
    {
        // Get all customers from all trips
        var allCustomers = await _tripInfoRepository.GetCustomersAsync();

        // Exclude customers with null tips
        allCustomers = allCustomers.Where(c => c.CustomerTip != null).ToList();

        // Find the customer with the highest tip
        var customerWithHighestTip = allCustomers.OrderByDescending(c => c.CustomerTip).FirstOrDefault();

        return customerWithHighestTip;
    }

    public async Task<IEnumerable<MetaData>> GetSumOfTipsByStoreName()
    {
        // Get all MetaData from all trips
        var allMetaData = await _tripInfoRepository.GetMetaDataListAsync();

        // filter StoreName 

        // Find the sum of tips for each store
        var sumOfTipsByStoreName = allMetaData.GroupBy(m => m.StoreName)
            .Select(g => new MetaData
            {
                StoreName = g.Key,
                Tip = g.Sum(m => m.Tip)
            });

        // Rank the stores by the sum of tips
        var rankedStores = sumOfTipsByStoreName.OrderByDescending(m => m.Tip).ToList();

        return rankedStores;
    }

    public async Task<IEnumerable<MetaData>> GetSumOfTipsByCity()
    {
        var allMetaData = await _tripInfoRepository.GetMetaDataListAsync();

        // Find the sum of tips for each city
        var sumOfTipsByCity = allMetaData.GroupBy(m => m.City)
            .Select(g => new MetaData
            {
                City = g.Key,
                Tip = g.Sum(mbox => mbox.Tip)
            });

        // Rank the stores by the sum of tips
        var rankedCities = sumOfTipsByCity.OrderByDescending(m => m.Tip).ToList();

        return rankedCities;
    }

    public async Task<IEnumerable<MetaData>> GetSumOfTipsByZip()
    {
        var allMetaData = await _tripInfoRepository.GetMetaDataListAsync();

        // Find the sum of tips for each Zip Code
        var sumOfTipsByZipCode = allMetaData.GroupBy(m => m.Zip)
            .Select(g => new MetaData
            {
                Zip = g.Key,
                Tip = g.Sum(m => m.Tip)
            });

        // Rank the Zip Codes by the sum of tips
        var rankedZipCodes = sumOfTipsByZipCode.OrderByDescending(m => m.Tip).ToList();

        return rankedZipCodes;
    }

    public async Task<IEnumerable<MetaData>> GetSumOfTipsByMonth()
    {
        var allMetaData = await _tripInfoRepository.GetMetaDataListAsync();

        var sumOfTipsByMonth = allMetaData
            .GroupBy(m => m.DateTime.Month)
            .Select(g => new MetaData
            {
                DateTime = new DateTime(1, g.Key, 1), // Create a DateTime object with the month number
                Tip = g.Sum(m => m.Tip)
            })
            .OrderByDescending(m => m.Tip)
            .ToList();

        return sumOfTipsByMonth;
    }
}
