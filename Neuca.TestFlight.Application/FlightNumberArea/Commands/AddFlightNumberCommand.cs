using MediatR;

namespace Neuca.TestFlight.Application.FlightNumberArea.Commands;

public record AddFlightNumberCommand(string Code, string From, string To, string Days, string Continent) : IRequest;
