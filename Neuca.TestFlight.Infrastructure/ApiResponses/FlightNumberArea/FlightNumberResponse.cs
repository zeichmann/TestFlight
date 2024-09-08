using System.Text.Json.Serialization;
using Neuca.TestFlight.Domain.Enums;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightPriceArea;

namespace Neuca.TestFlight.Infrastructure.ApiResponses.FlightNumberArea;

public class FlightNumberResponse
{
    public Guid Id { get; set; }
    
    public string Code { get; private set; }
    
    public string From { get; private set; } 
    
    public string To { get; private set; }
    
    public string Continent { get; private set; }
    
    [JsonIgnore]
    public DaysOfWeek AvailableDaysOfWeek { get; set; }

    public string AvailableDaysOfWeekTxt
    {
        get { return AvailableDaysOfWeek.ToString(); }
    }

    public List<FlightPriceResponse> Prices { get; set; }

}