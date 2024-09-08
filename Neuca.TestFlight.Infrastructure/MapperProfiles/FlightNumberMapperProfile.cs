using AutoMapper;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightNumberArea;

namespace Neuca.TestFlight.Infrastructure.MapperProfiles;

public class FlightNumberMapperProfile : Profile 
{
    public FlightNumberMapperProfile()
    {
        CreateMap<FlightNumber, FlightNumberResponse>()
            .ForMember(dest => dest.Prices, opt => opt.MapFrom(src => src.Prices));
    }
    
    
}