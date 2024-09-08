using MediatR;
using Neuca.TestFlight.Application.FlightNumberArea.Commands;
using Neuca.TestFlight.Domain.Enums;
using Neuca.TestFlight.Infrastructure;

namespace Neuca.TestFlight.Application.FlightNumberArea.CommandHandlers;

public class AddFlightNumberCommandHandler(InMemoryDbContext ctx) : IRequestHandler<AddFlightNumberCommand>
{
    public Task Handle(AddFlightNumberCommand request, CancellationToken cancellationToken)
    {
        ctx.FlightNumbers.Add(Domain.AggregateRoots.FlightNumber.Create(request.From, request.To, request.Code,
            DaysParser.Convert(request.Days.Split(',')), request.Continent));
        ctx.SaveChanges();

        return Task.CompletedTask;
    }
}