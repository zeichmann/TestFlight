using MediatR;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightNumberArea;

namespace Neuca.TestFlight.Application.FlightNumberArea.Queries;

public record GetFlightNumbersQuery : IRequest<List<FlightNumberResponse>>;