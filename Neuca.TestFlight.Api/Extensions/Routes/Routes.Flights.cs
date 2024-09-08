using MediatR;
using Neuca.TestFlight.Application.FlightArea.Queries;

namespace Neuca.TestFlight.Api.Extensions.Routes;

public static partial class RoutesExtensions
{
    public static WebApplication DefineFlightsRoutes(this WebApplication app)
    {
        app.MapGet("/flights", async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new GetFlightsQuery())); 
        });
        return app;
    }
}