using MediatR;
using Neuca.TestFlight.Application.FlightNumberArea.Queries;
using Neuca.TestFlight.Infrastructure;

namespace Neuca.TestFlight.Api.Extensions.Routes;

public static partial class RoutesExtensions
{
    public static WebApplication DefineFlightNumbersRoutes(this WebApplication app)
    {
        app.MapGet("/flight-numbers", async (IMediator mediator, InMemoryDbContext dbContext) =>
        {
            return Results.Ok(await mediator.Send(new GetFlightNumbersQuery())); 
        });
        
        return app;
    }
}