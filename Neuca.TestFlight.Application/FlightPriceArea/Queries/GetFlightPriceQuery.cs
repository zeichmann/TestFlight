using MediatR;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightPriceArea;

namespace Neuca.TestFlight.Application.FlightPriceArea.Queries;

public record GetFlightPriceQuery(string FlightId) : IRequest<FlightDiscountedPriceResponse>;