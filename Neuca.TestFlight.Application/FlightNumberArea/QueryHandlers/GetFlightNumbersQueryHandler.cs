using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Neuca.TestFlight.Application.FlightNumberArea.Queries;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightNumberArea;

namespace Neuca.TestFlight.Application.FlightNumberArea.QueryHandlers;

public class GetFlightNumbersQueryHandler(IMapper mapper, InMemoryDbContext ctx) : IRequestHandler<GetFlightNumbersQuery, List<FlightNumberResponse>>
{
    public Task<List<FlightNumberResponse>> Handle(GetFlightNumbersQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(mapper.Map<List<FlightNumberResponse>>(ctx.FlightNumbers.Include(x=>x.Prices).ToList()));
    }
}

