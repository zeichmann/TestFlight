using AutoMapper;
using MediatR;
using Neuca.TestFlight.Application.FlightPriceArea.Queries;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightPriceArea;

namespace Neuca.TestFlight.Application.FlightPriceArea.QueryHandlers;

public class GetFlightPricesQueryHandler(IMapper mapper, InMemoryDbContext ctx) : IRequestHandler<GetFlightPricesQuery, List<FlightPriceResponse>>
{
    public Task<List<FlightPriceResponse>> Handle(GetFlightPricesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(mapper.Map<List<FlightPriceResponse>>(ctx.FlightPrices.ToList()));
    }
}

