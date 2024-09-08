using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;

namespace Neuca.TestFlight.Domain.Abstractions;

public interface ITenantService
{
    public decimal CountPrice(NeucaUser user, Flight flight);
}