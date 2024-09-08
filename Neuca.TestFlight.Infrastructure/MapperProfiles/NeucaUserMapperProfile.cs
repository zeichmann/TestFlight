using AutoMapper;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;
using Neuca.TestFlight.Infrastructure.ApiResponses.NeucaUserArea;

namespace Neuca.TestFlight.Infrastructure.MapperProfiles;

public class NeucaUserMapperProfile : Profile 
{
    public NeucaUserMapperProfile()
    {
        CreateMap<NeucaUser, NeucaUserResponse>()
            .ForMember(dest => dest.Tenant, opt => opt.MapFrom(src => src.Tenant))
            .ForMember(dest => dest.Criteria, opt => opt.MapFrom(src => src.Criteria));
    }
    
    
}