using System.Dynamic;
using Neuca.TestFlight.Domain.DomainExceptions;
using Neuca.TestFlight.Domain.Enums;
using NeucaTestFlight.Abstraction;

namespace Neuca.TestFlight.Domain.AggregateRoots;

public class Flight : AggregateRoot
{
    private Flight()
    {
    }

    public string FlightId
    {
        get { return FlightNumber?.Code + IndividualId; }
    }

    public string IndividualId { get; set; }
    
    public virtual Guid FlightNumberId { get; set; }
    
    public FlightNumber FlightNumber { get; set; }
    
    public DateTime FlightTime { get; set; }

    public static Flight Create(FlightNumber flightNumber, string individualId, DateTime flyTime)
    {
        var result = new Flight()
        {
            FlightNumber = flightNumber,
            FlightTime = flyTime,
            IndividualId = individualId,
        };

        if (!result.CheckDaysConsistency())
        {
            throw new DomainException()
            {
                Code = "1",
                Message = "Inconsistent days condition"
            };
        }

        return result;
    }

    private bool CheckDaysConsistency()
    {
        var scheduleDay = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), FlightTime.DayOfWeek.ToString());

        return (scheduleDay & FlightNumber.AvailableDaysOfWeek) == scheduleDay;
    }
}