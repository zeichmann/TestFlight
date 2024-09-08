using Neuca.TestFlight.Domain.Abstractions;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.DomainExceptions;

namespace TenantB;

public class TenantService : ITenantService
{
    public decimal CountPrice(NeucaUser user, Flight flight)
    {
        var flyHour = new TimeSpan(flight.FlightTime.Hour, flight.FlightTime.Minute, flight.FlightTime.Second);
        decimal initialPrice = 0;
        var currentPrice = flight.FlightNumber.Prices.FirstOrDefault(x => x.Hour.ToString() == flyHour.ToString());

        if (currentPrice == null)
        {
            throw new DomainException()
            {
                Message = "No flight in this time"
            };
        }

        initialPrice = currentPrice.Price;
        decimal totalDiscount = 0;

        if (user.DateOfBirth.Month == flight.FlightTime.Month && user.DateOfBirth.Day == flight.FlightTime.Day)
        {
            totalDiscount += 5;
        }

        if (flight.FlightNumber.Continent == "Africa")
        {
            totalDiscount += 5;
        }

        if (initialPrice - totalDiscount < 20)
        {
            return initialPrice;
        }

        return initialPrice - totalDiscount;
    }
}