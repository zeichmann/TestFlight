using System.Text.Json.Serialization;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.DomainExceptions;
using Neuca.TestFlight.Domain.Enums;
using NeucaTestFlight.Abstraction;

namespace Neuca.TestFlight.Domain.ValueObjects;

public class FlightPrice : ValueObject
{
    private FlightPrice() { }

    public Guid FlightNumberId { get; set; }
    
    [JsonIgnore]
    public FlightNumber FlightNumber { get; set; }
    
    public DaysOfWeek DayOfWeek { get; private set; } 
        
    public TimeSpan Hour { get; private set; }
    
    public decimal Price { get; private set; }

    public static FlightPrice Create(Guid flightNumberId, DaysOfWeek availableDaysOfWeek, DaysOfWeek dayOfWeek, TimeSpan hour, decimal defaultPrice)
    {
        if ((dayOfWeek & availableDaysOfWeek) != dayOfWeek)
        {
            throw new DomainException()
            {
                Message = "Cannot set price for this date",
            };
        }
        
        return new FlightPrice()
        {
            FlightNumberId = flightNumberId,
            DayOfWeek = dayOfWeek,
            Hour = hour,
            Price = defaultPrice
        };
    }
}