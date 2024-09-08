using System.Dynamic;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.Enums;
using Neuca.TestFlight.Domain.ValueObjects;
using NeucaTestFlight.Abstraction;

namespace Neuca.TestFlight.Domain.AggregateRoots; 

public class FlightNumber : AggregateRoot
{
    private FlightNumber() { }

    public string Code { get; private set; }
    
    public string From { get; private set; } 
    
    public string To { get; private set; }
    
    public string Continent { get; private set; }
        
    public static FlightNumber Create(string from, string to, string code, DaysOfWeek availableDaysOfWeek, string continent)
    {
        return new FlightNumber()
        {
            Code = code,
            To = to,
            From = from,
            AvailableDaysOfWeek = availableDaysOfWeek,
            Prices = new List<FlightPrice>(),
            Continent = continent
        };
    }
    
    public DaysOfWeek AvailableDaysOfWeek { get; set; }
    
    [JsonIgnore]
    public List<FlightPrice> Prices { get; set; }

    [JsonIgnore]
    public List<Flight> Flights { get; set; }
}
