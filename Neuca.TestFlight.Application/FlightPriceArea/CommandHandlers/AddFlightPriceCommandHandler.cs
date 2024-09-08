using MediatR;
using Neuca.TestFlight.Application.FlightPriceArea.Commands;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.DomainExceptions;
using Neuca.TestFlight.Domain.Enums;
using Neuca.TestFlight.Domain.ValueObjects;
using Neuca.TestFlight.Infrastructure;

namespace Neuca.TestFlight.Application.FlightPriceArea.CommandHandlers;

public class AddFlightPriceCommandHandler(InMemoryDbContext ctx) :  IRequestHandler<AddFlightPriceCommand>
{
        public Task Handle(AddFlightPriceCommand request, CancellationToken cancellationToken)
        {
            var hourValues = request.Hour.Split(':');

            TimeSpan hour = new TimeSpan(Convert.ToInt32(hourValues[0]), Convert.ToInt32(hourValues[1]), 0);

            FlightNumber fn = null;
            if (request.FlightNumberId.HasValue)
                fn = ctx.FlightNumbers.Find(request.FlightNumberId);
            if (!string.IsNullOrEmpty(request.FlightCode))
                fn = ctx.FlightNumbers.FirstOrDefault(x=>x.Code.Equals(request.FlightCode));
            
            if (Enum.TryParse(request.Day, out DaysOfWeek dayOfWeek))
            {
                ctx.FlightPrices.Add(FlightPrice.Create(fn.Id, fn.AvailableDaysOfWeek, dayOfWeek, hour, request.price));
                ctx.SaveChanges();
                
                return Task.CompletedTask;
            }

            throw new DomainException()
            {
                Message = "Wrong day conversion"
            };
        }
 }