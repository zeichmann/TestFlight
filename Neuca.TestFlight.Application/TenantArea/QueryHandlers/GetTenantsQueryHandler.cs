using AutoMapper;
using MediatR;
using Neuca.TestFlight.Application.TenantArea.Queries;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.ApiResponses.TenantArea;

namespace Neuca.TestFlight.Application.TenantArea.QueryHandlers;

public class GetTenantsQueryHandler(IMapper mapper, InMemoryDbContext dbContext)
    : IRequestHandler<GetTenantsQuery, List<TenantResponse>>
{
    public async Task<List<TenantResponse>> Handle(GetTenantsQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<List<TenantResponse>>(dbContext.Tenants.ToList());
    }
}