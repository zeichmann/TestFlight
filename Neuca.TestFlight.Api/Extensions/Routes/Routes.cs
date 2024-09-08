namespace Neuca.TestFlight.Api.Extensions.Routes;

public static partial class RoutesExtensions
{
    public static WebApplication DefineRoutes(this WebApplication app)
    {
        app.DefineCriteriaRoutes();
        app.DefineFlightsRoutes();
        app.DefineFlightNumbersRoutes();
        app.DefineFlightPricesRoutes();
        app.DefineTenantsRoutes();
        app.DefineNeucaUsersRoutes();
        
        return app;
    }
}