using AutoMapper; // IMapper
using Microsoft.AspNetCore.Authorization; // Authorize annotation
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch; // JsonPatchDocument
using Microsoft.AspNetCore.Mvc; // ApiController, ActionResult, ControllerBase, FromQuery, HttpGet, Ok, Route
using TripInfo.API.Models; // CustomerDto, CustomerForCreationDto, CustomerForUpdateDto
using TripInfo.API.Services.MailServices;
using TripInfo.API.Services.Repositories;  // IMailService, ITripInfoRepository

namespace TripInfo.API.Controllers;

[Route("api/v{version:apiVersion}/trips/{tripId}/customers")]
//[Authorize] 
[ApiVersion("2.0")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ILogger<CustomersController> _logger;
    private readonly IMailService _mailService;
    private readonly ITripInfoRepository _tripInfoRepository;
    private readonly IMapper _mapper;

    public CustomersController(ILogger<CustomersController> logger,
        IMailService mailService,
        ITripInfoRepository tripInfoRepository,
        IMapper mapper)
    {
        _logger = logger ?? 
            throw new ArgumentNullException(nameof(logger));
        _mailService = mailService ?? 
            throw new ArgumentNullException(nameof(mailService));
        _tripInfoRepository = tripInfoRepository ?? 
            throw new ArgumentNullException(nameof(tripInfoRepository));
        _mapper = mapper ?? 
            throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers(
        int tripId)
    {

        //var cityname = user.claims.firstordefault(t => t.type == "city").value;

        //if (!await _tripinforepository.citynamematchestripid(cityname, tripid))
        //{
        //    return forbid(); // 403 status code
        //}

        if (!await _tripInfoRepository.TripExistsAsync(tripId)) // checks if the collection exists
        {
            _logger.LogInformation(
                $"Trip with id {tripId} wasn't found when accessing customers.");
            return NotFound();
        }

        var customersForTrip = await _tripInfoRepository
            .GetCustomersForTripAsync(tripId);

        return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customersForTrip));
    }

    [HttpGet("{customerid}", Name = "GetCustomer")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(
        int tripId, int customerId)
    {
        if (!await _tripInfoRepository.TripExistsAsync(tripId)) // checks if the trip exists
        {
            _logger.LogInformation(
                $"Trip with id {tripId} wasn't found when accessing customers.");
            return NotFound();
        }

        var customer = await _tripInfoRepository
            .GetCustomerForTripAsync(tripId, customerId);

        if (customer == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CustomerDto>(customer));
    }

    // The first time persisting through Entity Framework Core
    [HttpPost]
    public async Task<ActionResult<CustomerDto>> CreateCustomer(
        int tripId, CustomerForCreationDto customer)
    {
        if (!await _tripInfoRepository.TripExistsAsync(tripId)) // checks if the trip exists
        {
            return NotFound();
        }

        var finalCustomer = _mapper.Map<Entities.Customer>(customer);

        await _tripInfoRepository.AddCustomerForTripAsync(
            tripId, finalCustomer);

        await _tripInfoRepository.SaveChangesAsync();

        var createdCustomerToReturn = 
            _mapper.Map<CustomerDto>(finalCustomer);

        return CreatedAtRoute("GetCustomer",
            new
            {
                tripId = tripId,
                customerId = createdCustomerToReturn.Id
            },
            createdCustomerToReturn);
    }

    [HttpPut("{customerid}")]
    public async Task<ActionResult> UpdateCustomer(
        int tripId, 
        int customerId,
        CustomerForUpdateDto customer)
    {
        if (!await _tripInfoRepository.TripExistsAsync(tripId))
        {
            return NotFound();
        }

        var customerEntity = await _tripInfoRepository
            .GetCustomerForTripAsync(tripId, customerId);
        if (customerEntity == null)
        {
            return NotFound();
        }

        _mapper.Map(customer, customerEntity);

        await _tripInfoRepository.SaveChangesAsync();

        return NoContent(); // a 204 no content response
    }

    [HttpPatch("{customerid}")]
    public async Task<ActionResult> PartiallyUpdateCustomer(
        int tripId, 
        int customerId,
        JsonPatchDocument<CustomerForUpdateDto> patchDocument)
    {
        if (!await _tripInfoRepository.TripExistsAsync(tripId))
        {
            return NotFound(); 
        }

        var customerEntity = await _tripInfoRepository
            .GetCustomerForTripAsync(tripId, customerId);
        if (customerEntity == null)
        {
            return NotFound();
        }


        var customerToPatch = _mapper.Map<CustomerForUpdateDto>(
            customerEntity); 

        patchDocument.ApplyTo(customerToPatch, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // returns bad request if the model state is not valid, meaning you cannot update the model in a way that makes it invalid after a potential patch. not allowed to break the model. 
        if (!TryValidateModel(customerToPatch))
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(customerToPatch, customerEntity); 

        await _tripInfoRepository.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{customerid}")]
    public async Task<ActionResult> DeleteCustomer(
        int tripId, 
        int customerId)
    {
        if (!await _tripInfoRepository.TripExistsAsync(tripId))
        {
            return NotFound();
        }

        var customerEntity = await _tripInfoRepository
            .GetCustomerForTripAsync(tripId, customerId);
        if (customerEntity == null)
        {
            return NotFound();
        }

        _tripInfoRepository.DeleteCustomer(customerEntity); 

        await _tripInfoRepository.SaveChangesAsync();

        _mailService.Send("Customer deleted.",
                           $" Customer {customerEntity.Id} was deleted:\n" +
                           $" Customer Tip ${customerEntity.CustomerPrice}\n" +
                           $" Customer Price ${customerEntity.CustomerTip} \n" +
                           $" Customer Service Fee ${customerEntity.CustomerServiceFee}"
                           );

        return NoContent();
    }
}
