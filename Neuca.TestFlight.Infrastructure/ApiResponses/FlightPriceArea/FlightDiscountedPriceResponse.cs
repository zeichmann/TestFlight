using Neuca.TestFlight.Infrastructure.ApiResponses.FlightArea;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightNumberArea;

namespace Neuca.TestFlight.Infrastructure.ApiResponses.FlightPriceArea;

public class FlightDiscountedPriceResponse
{
    public decimal Price { get; set; }
    
    public Guid Id { get; set; }
    
    public string FlightId
    {
        get { return FlightNumber?.Code + IndividualId; }
    }

    public string IndividualId { get; set;}
    
    public virtual Guid FlightNumberId { get; set;}
    
    public FlightNumberResponse FlightNumber { get; set;}
    
    public DateTime FlightTime { get; set;}
}