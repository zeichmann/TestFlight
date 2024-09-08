using Neuca.TestFlight.Application.Services.Abstract;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Infrastructure.IdentityEmulator;

namespace Neuca.TestFlight.Application.Services;

public class PriceServiceLocator : TenantServiceLocator
{
    public PriceServiceLocator(IdentityService identityService) : base(identityService)
    {
    }

    public decimal GetPrice(NeucaUser user, Flight flight)
    {
        return tenantService.CountPrice(user, flight);
    }
}