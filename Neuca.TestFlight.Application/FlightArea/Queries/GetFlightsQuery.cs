using MediatR;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightArea;

namespace Neuca.TestFlight.Application.FlightArea.Queries;

public record GetFlightsQuery : IRequest<List<FlightResponse>>;