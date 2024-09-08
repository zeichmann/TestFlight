using MediatR;
using Microsoft.AspNetCore.Mvc;
using Neuca.TestFlight.Application.NeucaUserArea.Queries;
using Neuca.TestFlight.Infrastructure;

namespace Neuca.TestFlight.Api.Extensions.Routes;

public static partial class RoutesExtensions
{
    public static WebApplication DefineNeucaUsersRoutes(this WebApplication app)
    {
        app.MapGet("/me", async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new GetLoggedUserQuery())); 
        });
        
        app.MapGet("/neuca-users", async (IMediator mediator) =>
        {
            return Results.Ok(await mediator.Send(new GetNeucaUsersQuery())); 
        });
        
        app.MapPost("/sign-in", async (string username) =>
        {
            IdentitySessionState.User = username;
            return Results.Ok(IdentitySessionState.User); 
        });
        
        return app;
    }
}