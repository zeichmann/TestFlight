using MediatR;
using Microsoft.EntityFrameworkCore;
using Neuca.TestFlight.Application.FlightArea.Commands;
using Neuca.TestFlight.Domain.DomainExceptions;
using Neuca.TestFlight.Domain.Enums;
using Neuca.TestFlight.Infrastructure;

namespace Neuca.TestFlight.Application.FlightArea.CommandHandlers;

public class AddFlightCommandHandler(InMemoryDbContext ctx) :  IRequestHandler<AddFlightCommand>
{
        public Task Handle(AddFlightCommand request, CancellationToken cancellationToken)
        {
            var dayOfWeek = request.FlightTime.DayOfWeek.ToString();
            var hour = request.FlightTime.Hour;
            var minute = request.FlightTime.Minute;
            var flightNumber = ctx.FlightNumbers.Include(x=>x.Prices).FirstOrDefault(x => x.Id == request.FlightNumberId);
            
            DaysOfWeek scheduleDay = (DaysOfWeek)request.FlightTime.DayOfWeek;
            if ((scheduleDay & flightNumber.AvailableDaysOfWeek) == scheduleDay)
            {
                if (!flightNumber.Prices.Any(x => x.Hour.ToString() == new TimeSpan(hour, minute, 0).ToString()))
                {
                    throw new DomainException()
                    {
                        Message = "Flight with such and hour does not exist"
                    };
                }

                ctx.Flights.Add(Domain.AggregateRoots.Flight.Create(flightNumber, request.IndividualId,
                    request.FlightTime));
                ctx.SaveChanges();
            }
            
            return Task.CompletedTask;
        }
 }