using MediatR;
using Microsoft.AspNetCore.Mvc;
using Neuca.TestFlight.Application.FlightPriceArea.Commands;
using Neuca.TestFlight.Application.FlightPriceArea.Queries;
using Neuca.TestFlight.Application.Services;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.IdentityEmulator;

namespace Neuca.TestFlight.Api.Extensions.Routes;

public static partial class RoutesExtensions
{
    public static WebApplication DefineFlightPricesRoutes(this WebApplication app)
    {
        app.MapGet("/flight-prices", async (IMediator mediator, InMemoryDbContext dbContext) =>
        {
            return Results.Ok(await mediator.Send(new GetFlightPricesQuery())); 
        });
        
        app.MapPost("/flight-prices", async (IMediator mediator, [FromBody] AddFlightPriceCommand command) =>
        {
            await mediator.Send(command);
            return Results.Created();
        });
        
        app.MapGet("/me/prices", async (IdentityService identityService, IMediator mediator, PriceServiceLocator priceService, InMemoryDbContext context, string flightId) =>
        {
            return Results.Ok(await mediator.Send(new GetFlightPriceQuery(flightId)));
        });
        
        return app;
    }
}