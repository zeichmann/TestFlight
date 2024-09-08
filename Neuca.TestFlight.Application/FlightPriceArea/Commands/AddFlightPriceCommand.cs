using MediatR;

namespace Neuca.TestFlight.Application.FlightPriceArea.Commands;

public record AddFlightPriceCommand(Guid? FlightNumberId, string? FlightCode, string Day, string Hour, decimal price) : IRequest;