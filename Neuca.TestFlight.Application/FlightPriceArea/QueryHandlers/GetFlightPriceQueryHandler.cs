using System.Diagnostics.Eventing.Reader;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Neuca.TestFlight.Application.FlightPriceArea.Queries;
using Neuca.TestFlight.Application.Services;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.DomainExceptions;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.ApiResponses.FlightPriceArea;
using Neuca.TestFlight.Infrastructure.IdentityEmulator;

namespace Neuca.TestFlight.Application.FlightPriceArea.QueryHandlers;

public class GetFlightPriceQueryHandler(IMapper mapper, InMemoryDbContext dbContext, IdentityService identityService, PriceServiceLocator priceServiceLocator) : IRequestHandler<GetFlightPriceQuery, FlightDiscountedPriceResponse>
{
    public Task<FlightDiscountedPriceResponse> Handle(GetFlightPriceQuery request, CancellationToken cancellationToken)
    {
        Flight flight = null;
        FlightDiscountedPriceResponse result;
        if (Guid.TryParse(request.FlightId, out Guid parsedId))
        {
            flight = dbContext.Flights
                .Include(x => x.FlightNumber)
                .ThenInclude(x => x.Prices)
                .FirstOrDefault(x => x.Id == parsedId);
        } else
        {
            flight = dbContext.Flights
                .Include(x => x.FlightNumber)
                .ThenInclude(x => x.Prices)
                .FirstOrDefault(x => x.FlightNumber.Code + x.IndividualId == request.FlightId);
        }

        if (flight != null)
        {
            result = mapper.Map<FlightDiscountedPriceResponse>(flight);
            result.Price = priceServiceLocator.GetPrice(identityService.LoggedUser(), flight);
        }
        else
        {
            throw new DomainException()
            {
                Message = "Flight not found"
            };
        }

        return Task.FromResult(result);
    }
}

