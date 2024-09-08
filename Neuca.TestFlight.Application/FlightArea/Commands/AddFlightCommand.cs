using MediatR;

namespace Neuca.TestFlight.Application.FlightArea.Commands;

public record AddFlightCommand(string IndividualId, Guid FlightNumberId, DateTime FlightTime) : IRequest;
