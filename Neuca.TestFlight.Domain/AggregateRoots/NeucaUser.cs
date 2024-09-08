using System.Dynamic;
using NeucaTestFlight.Abstraction;

namespace Neuca.TestFlight.Domain.AggregateRoots;

public class NeucaUser : AggregateRoot
{
    private NeucaUser()
    {
    }

    public string Nickname { get; set; }
    
    public Guid TenantId { get; set; }
    
    public Tenant Tenant { get; set; }
    
    public DateOnly DateOfBirth { get; set; }
    
    public List<Criteria> Criteria { get; set; }


    public static NeucaUser Create(string nickname, Guid tenantId, DateOnly dateOfBirth)
    {
        return new NeucaUser() { Nickname = nickname, TenantId = tenantId, DateOfBirth = dateOfBirth };
    }
    
}