using MediatR;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightPriceArea;

namespace Neuca.TestFlight.Application.FlightPriceArea.Queries;

public record GetFlightPricesQuery : IRequest<List<FlightPriceResponse>>;