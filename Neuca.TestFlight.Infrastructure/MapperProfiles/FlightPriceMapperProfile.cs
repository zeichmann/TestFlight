using AutoMapper;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightArea;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightPriceArea;

namespace Neuca.TestFlight.Infrastructure.MapperProfiles;

public class FlightPriceMapperProfile : Profile 
{
    public FlightPriceMapperProfile()
    {
        CreateMap<FlightPrice, FlightPriceResponse>();
    }
    
    
}