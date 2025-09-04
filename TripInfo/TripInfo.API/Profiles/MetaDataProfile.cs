using AutoMapper;

namespace TripInfo.API.Profiles;

public class MetaDataProfile : Profile
{
    public MetaDataProfile()
    {
        CreateMap<Entities.MetaData, Models.MetaDataDto>();
    }
}
