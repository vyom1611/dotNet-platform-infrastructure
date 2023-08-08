using AutoMapper;

namespace PlatformService.Profiles;

public class PlatformProfile : Profile
{
    public PlatformProfile()
    {
        // Source -> Target
        CreateMap<Models.Platform, DTOs.PlatformReadDto>();
        CreateMap<DTOs.PlatformCreateDto, Models.Platform>();
    }
}