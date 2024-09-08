using System.Text.Json.Serialization;
using NeucaTestFlight.Abstraction;

namespace Neuca.TestFlight.Domain.AggregateRoots;

public class Criteria : AggregateRoot
{
    public Guid UserId { get; set; }
   
    public NeucaUser User { get; set; }
    
    public Guid TenantId { get; set; }
   
    public Tenant Tenant { get; set; }
    
    public string CriteriaName { get; set; }
    
    public decimal InitialPrice { get; set; }
    
    public Guid FlightId { get; set; }
    
    public decimal Discount { get; set; }

    public static Criteria Create(Guid userId, Guid tenantId, string criteriaName, decimal initialPrice,
        decimal discountedPrice, Guid flightId)
    {
        return new Criteria()
        {
            UserId = userId,
            TenantId = tenantId,
            Discount = discountedPrice,
            CriteriaName = criteriaName,
            FlightId = flightId,
            InitialPrice = initialPrice
        };
    }
}