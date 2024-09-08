using MediatR;
using Neuca.TestFlight.Application.TenantArea.Queries;

namespace Neuca.TestFlight.Api.Extensions.Routes;

public static partial class RoutesExtensions
{
    public static WebApplication DefineTenantsRoutes(this WebApplication app)
    {
        app.MapGet("/tenants", async (IMediator mediator) =>
        {
            return Results.Ok(mediator.Send(new GetTenantsQuery())); 
        });
        
        return app;
    }
}