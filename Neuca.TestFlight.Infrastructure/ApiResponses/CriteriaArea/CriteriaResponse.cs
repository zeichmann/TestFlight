using Neuca.TestFlight.Infrastructure.ApiResponses.NeucaUserArea;
using Neuca.TestFlight.Infrastructure.ApiResponses.TenantArea;

namespace Neuca.TestFlight.Infrastructure.ApiResponses.CriteriaArea;

public class CriteriaResponse
{
    public Guid Id { get; set; }
   
    public Guid UserId { get; set; }
   
    public Guid TenantId { get; set; }
    
    public string CriteriaName { get; set;}
    
    public decimal InitialPrice { get; set;}
    
    public decimal Discount { get; set; }
    
    public Guid FlightId { get; set;}
}