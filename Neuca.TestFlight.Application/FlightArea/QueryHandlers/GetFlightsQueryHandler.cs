using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Neuca.TestFlight.Application.FlightArea.Queries;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightArea;

namespace Neuca.TestFlight.Application.FlightArea.QueryHandlers;

public class GetFlightsQueryHandler(IMapper mapper, InMemoryDbContext ctx) : IRequestHandler<GetFlightsQuery, List<FlightResponse>>
{
    public Task<List<FlightResponse>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(mapper.Map<List<FlightResponse>>(ctx.Flights.Include(x=>x.FlightNumber).ThenInclude(x=>x.Prices).ToList()));
    }
}