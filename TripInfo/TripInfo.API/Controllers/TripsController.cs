using AutoMapper; // IMapper
using Microsoft.AspNetCore.Authorization; // Authorize annotation
using Microsoft.AspNetCore.Mvc; // ApiController, ActionResult, ControllerBase, FromQuery, HttpGet, Ok, Route
using System.Globalization;
using System.Text.Json; // JsonSerializer
using System.Threading.Tasks;
using TripInfo.API.Entities;
using TripInfo.API.Models; // TripDto, TripWithoutCustomersDto
using TripInfo.API.Services.MailServices;
using TripInfo.API.Services.Repositories; 
using TripInfo.API.Services.TripInfoServices; 

/// <summary>
/// A JsonResult is an ActionResult (Wrapper) that formats the given object as Json Implement's IActionResult
/// </summary>
/// <remarks>
/// I do not have to explicitly return a Json object because ActionResult can return any format the client 
/// wants. If an exception that is not handled happens, then the framework will automatically return a 500 
/// Internal Server Status Code error.
/// </remarks>
namespace TripInfo.API.Controllers;

/// <summary>
/// Configures this controller with features and behaviors aiming to improve the development experience when building APIs
/// </summary>
[ApiController]
[Authorize(Policy = "CanAccessTravelDetails")]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/trips")]
public class TripsController : ControllerBase
{
    private readonly IMailService _mailService;
    private readonly ITripInfoRepository _tripInfoRepository;
    private readonly ITripInfoService _tripInfoService;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;
    const int maxTripsPageSize = 20;
    // const int maxCustomersPageSize = 30; //have individual max constants per resource

    public TripsController(ITripInfoRepository tripInfoRepository,ITripInfoService tripInfoService,
        IMapper mapper, IMailService mailService, IEmailService emailService)
    {
        _tripInfoRepository = tripInfoRepository ?? 
            throw new System.ArgumentNullException(nameof(tripInfoRepository));
        _tripInfoService = tripInfoService ??
            throw new ArgumentNullException(nameof(tripInfoService));
        _mapper = mapper ??
            throw new ArgumentNullException(nameof(mapper));
        _mailService = mailService ??
            throw new ArgumentNullException(nameof(mailService));
        _emailService = emailService ??
            throw new ArgumentNullException(nameof(emailService));
    }

    /// <summary>
    /// Returns a collection of trips.
    /// </summary>
    /// <param name="name">The store name of the trip to return.</param>
    /// <remarks>An empty collection is a valid response body. </remarks>
    /// <returns>An ActionResult object</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TripWithoutCustomersDto>>> GetTrips(
        string? name,
        string? searchQuery,
        int pageNumber = 1,
        int pageSize = 5)
    {
        if (pageSize > maxTripsPageSize)
        {
            pageSize = maxTripsPageSize;
        }

        var (tripEntities, paginationMetadata) = await _tripInfoRepository
            .GetTripsAsync(name,searchQuery, pageNumber, pageSize);

        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata)); // adds a header to the response


        // Note: I decided to add this business logic here as opposed to being a specific method in LocalMailService because it is specific to the TripsController
            //I would like input on this decision.
        
        var valuedCustomer = await _tripInfoService.GetCustomerWithHighestTipAsync();
        _mailService.SendMostValuableCustomerInformation($"Valued Customer Information:\n",
                                                         $"Customer ID: {valuedCustomer.Id}\n" +
                                                         $"Trip ID: {valuedCustomer.TripId}\n" +
                                                         $"Price: {valuedCustomer.CustomerPrice}\n" +
                                                         $"Tip: {valuedCustomer.CustomerTip}\n" +
                                                         $"Service Fee: {valuedCustomer.CustomerServiceFee}\n" +
                                                         $"Description: {valuedCustomer.Description}\n"
                                                        );
        
        return Ok(_mapper.Map<IEnumerable<TripWithoutCustomersDto>>(tripEntities)); // returns a list("IEnumerable") of TripWithoutCustomersDto objects
    }

    /// <summary>
    /// Returns a specific trip based on the provided id.
    /// </summary>
    /// <param name="id">The id of the trip to return.</param>
    /// <param name="includeCustomers">Whether or not to include customers in the response.</param>
    /// <returns>An IActionResult object.</returns>
    /// <response code="200">Returns the requested trip.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetTrip( // returns an IActionResult object rather than a ActionResult<TripDto> object
        int id,
        bool includeCustomers = false)
    {
        var trip = await _tripInfoRepository.GetTripAsync(id, includeCustomers); // await is used to wait for the task to complete rather than the task itself returned. 
        if (trip == null)
        {
            return NotFound();
        }

        if (includeCustomers)
        {
            return Ok(_mapper.Map<TripDto>(trip)); // returns a TripDto object
        }

        return Ok(_mapper.Map<TripWithoutCustomersDto>(trip)); // returns a TripWithoutCustomersDto object
    }
    
    [HttpGet("GetTravelDetails")]
    public async Task<ActionResult<IEnumerable<MetaDataDto>>> GetMetaDataList(
        string? name,
        string? searchQuery,
        int pageNumber = 1,
        int pageSize = 5)
    {
        if (pageSize > maxTripsPageSize)
        {
            pageSize = maxTripsPageSize;
        }

        var (metaDataEntities, paginationMetadata) = await _tripInfoRepository
            .GetMetaDataListAsync(name, searchQuery, pageNumber, pageSize);

        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata)); // adds a header to the response

        await _emailService.SendSumOfTipsByGroup(_tripInfoService.GetSumOfTipsByStoreName, "Tip's Information by Store Name", "StoreName");
        await _emailService.SendSumOfTipsByGroup(_tripInfoService.GetSumOfTipsByCity, "Tip's Information by City", "City");
        await _emailService.SendSumOfTipsByGroup(_tripInfoService.GetSumOfTipsByZip, "Tip's Information by Zip", "Zip");
        await _emailService.SendSumOfTipsByGroup(_tripInfoService.GetSumOfTipsByMonth, "Tip's Information by Month", "Month");

        return Ok(_mapper.Map<IEnumerable<MetaDataDto>>(metaDataEntities)); // returns a list("IEnumerable") of MetaDataDto objects
    }
}
