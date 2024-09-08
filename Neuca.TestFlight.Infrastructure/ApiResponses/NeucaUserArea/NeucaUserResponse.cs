using Neuca.TestFlight.Infrastructure.ApiResponses.CriteriaArea;
using Neuca.TestFlight.Infrastructure.ApiResponses.TenantArea;

namespace Neuca.TestFlight.Infrastructure.ApiResponses.NeucaUserArea;

public class NeucaUserResponse
{
    private Guid Id { get; set; }
    
    public string Nickname { get; set;}

    public Guid TenantId { get; set;}

    public TenantResponse Tenant { get; set;}

    public DateOnly DateOfBirth { get; set;}

    public List<CriteriaResponse> Criteria { get; set;}
}