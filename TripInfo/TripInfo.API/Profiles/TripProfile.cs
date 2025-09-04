using AutoMapper; // CreateMap

namespace TripInfo.API.Profiles;

public class TripProfile : Profile
{
    public TripProfile()
    {
        CreateMap<Entities.Trip, Models.TripWithoutCustomersDto>(); // source -> target therefore no worries about null values because they will be ignored.
        CreateMap<Entities.Trip, Models.TripDto>();
    }
}
