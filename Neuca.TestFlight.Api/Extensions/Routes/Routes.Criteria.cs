using MediatR;
using Neuca.TestFlight.Application.CriteriaArea.Queries;

namespace Neuca.TestFlight.Api.Extensions.Routes;

public static partial class RoutesExtensions
{
    public static WebApplication DefineCriteriaRoutes(this WebApplication app)
    {
        app.MapGet("/criteria", async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new GetCriteriaQuery())); 
        });
        
        return app;
    }
}