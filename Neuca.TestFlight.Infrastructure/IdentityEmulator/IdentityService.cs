using Microsoft.EntityFrameworkCore;
using Neuca.TestFlight.Domain.AggregateRoots;

namespace Neuca.TestFlight.Infrastructure.IdentityEmulator;

public class IdentityService(InMemoryDbContext context)
{
    public NeucaUser LoggedUser()
    {
        return context.NeucaUsers.Include(x=>x.Tenant)
            .Include(x=>x.Criteria)
            .FirstOrDefault(x => x.Nickname == IdentitySessionState.User);
    }
}