namespace Neuca.TestFlight.Infrastructure.ApiResponses.FlightPriceArea;

public class FlightPriceResponse
{
    public decimal Price { get; set; }
    
    public DayOfWeek DayOfWeek { get; set;}
    
    public string DayFormatted
    {
        get { return DayOfWeek.ToString(); }
    }
    
    public TimeSpan Hour { get; set; }

    public string HourFormatted
    {
        get { return Hour.ToString(@"hh\:mm"); }
    }
}