using AutoMapper;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;
using Neuca.TestFlight.Infrastructure.ApiResponses.TenantArea;

namespace Neuca.TestFlight.Infrastructure.MapperProfiles;

public class TenantMapperProfile : Profile 
{
    public TenantMapperProfile()
    {
        CreateMap<Tenant, TenantResponse>();
    }
}