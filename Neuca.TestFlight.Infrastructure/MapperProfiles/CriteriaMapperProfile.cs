using AutoMapper;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Infrastructure.ApiResponses.CriteriaArea;

namespace Neuca.TestFlight.Infrastructure.MapperProfiles;

public class CriteriaMapperProfile : Profile 
{
    public CriteriaMapperProfile()
    {
        CreateMap<Criteria, CriteriaResponse>();
    }
}