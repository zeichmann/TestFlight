using AutoMapper;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightArea;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightPriceArea;

namespace Neuca.TestFlight.Infrastructure.MapperProfiles;

public class FlightMapperProfile : Profile 
{
    public FlightMapperProfile()
    {
        CreateMap<Flight, FlightResponse>();
        
        CreateMap<Flight, FlightDiscountedPriceResponse>()
            .ForMember(dest => dest.FlightNumber, opt => opt.MapFrom(src => src.FlightNumber));
    }
    
    
}