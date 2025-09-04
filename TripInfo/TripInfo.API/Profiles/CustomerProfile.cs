using AutoMapper; // CreateMap 

namespace TripInfo.API.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Entities.Customer, Models.CustomerDto>();
        CreateMap<Models.CustomerForCreationDto, Entities.Customer>();
        CreateMap<Models.CustomerForUpdateDto, Entities.Customer>();
        CreateMap<Entities.Customer, Models.CustomerForUpdateDto>();
    }
}
