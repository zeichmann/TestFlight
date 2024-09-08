using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.Enums;
using Neuca.TestFlight.Domain.ValueObjects;
using Neuca.TestFlight.Infrastructure;

namespace Neuca.TestFlight.Api.Extensions.Seed;

public static class SeedExtension
{
    public static WebApplication Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<InMemoryDbContext>();

            dbContext.Add(FlightNumber.Create("Nowy Jork (JFK)", "Londyn (LHR)", "AAA100",
                DaysOfWeek.Monday | DaysOfWeek.Tuesday | DaysOfWeek.Saturday | DaysOfWeek.Sunday, "NotAfrica"));
            dbContext.Add(FlightNumber.Create("Boston (BOS)", "Londyn (LHR)", "BAA202",
                DaysOfWeek.Saturday | DaysOfWeek.Sunday, "NotAfrica"));
            dbContext.Add(FlightNumber.Create("Nowy Jork (JFK)", "Frankfurt (FRA)", "LHA401",
                DaysOfWeek.Saturday | DaysOfWeek.Sunday, "NotAfrica"));
            dbContext.Add(FlightNumber.Create("Nowy Jork (JFK)", "Paryż (CDG)", "AFA007",
                DaysOfWeek.Saturday | DaysOfWeek.Sunday, "NotAfrica"));
            dbContext.Add(FlightNumber.Create("Nowy Jork (JFK)", "Amsterdam (AMS)", "KLA642",
                DaysOfWeek.Saturday | DaysOfWeek.Sunday, "NotAfrica"));
            dbContext.Add(FlightNumber.Create("San Francisco (SFO)", "Londyn (LHR)", "UAA931",
                DaysOfWeek.Saturday | DaysOfWeek.Sunday, "NotAfrica"));
            dbContext.Add(FlightNumber.Create("Dubaj (DXB)", "Nowy Jork (JFK)", "EKA203",
                DaysOfWeek.Saturday | DaysOfWeek.Sunday, "NotAfrica"));
            dbContext.Add(FlightNumber.Create("Los Angeles (LAX)", "Sydney (SYD)", "QFA12",
                DaysOfWeek.Saturday | DaysOfWeek.Sunday, "NotAfrica"));
            dbContext.Add(FlightNumber.Create("Nowy Jork (JFK)", "Hongkong (HKG)", "CXA831",
                DaysOfWeek.Saturday | DaysOfWeek.Sunday, "NotAfrica"));
            dbContext.Add(FlightNumber.Create("Nowy Jork (JFK)", "Somalia Land", "SQA25",
                DaysOfWeek.Monday | DaysOfWeek.Saturday | DaysOfWeek.Sunday, "Africa"));
            dbContext.SaveChanges();

            var fn = dbContext.FlightNumbers.FirstOrDefault(x => x.Code == "AAA100");
            dbContext.Add(FlightPrice.Create(fn.Id, fn.AvailableDaysOfWeek, DaysOfWeek.Monday,
                new TimeSpan(10, 50, 0), 100));

            fn = dbContext.FlightNumbers.FirstOrDefault(x => x.Code == "SQA25");
            dbContext.Add(FlightPrice.Create(fn.Id, fn.AvailableDaysOfWeek, DaysOfWeek.Monday,
                new TimeSpan(10, 50, 0), 50));

            dbContext.Add(FlightPrice.Create(fn.Id, fn.AvailableDaysOfWeek, DaysOfWeek.Monday,
                new TimeSpan(17, 20, 0), 20));

            dbContext.SaveChanges();

            dbContext.Add(Tenant.Create("A", "TenantA.dll", "TenantA.TenantService"));
            dbContext.Add(Tenant.Create("B", "TenantB.dll", "TenantB.TenantService"));
            dbContext.SaveChanges();

            dbContext.Add(NeucaUser.Create("Adam", dbContext.Tenants.FirstOrDefault(x => x.Code == "A").Id,
                new DateOnly(1976, 11, 04)));

            dbContext.Add(NeucaUser.Create("Ewa", dbContext.Tenants.FirstOrDefault(x => x.Code == "B").Id,
                new DateOnly(1976, 12, 20)));
            dbContext.SaveChanges();

            fn = dbContext.FlightNumbers.FirstOrDefault(x => x.Code == "SQA25");
            dbContext.Add(Domain.AggregateRoots.Flight.Create(fn, "XKD", new DateTime(2024, 11, 04, 10, 50, 0)));
            dbContext.Add(Domain.AggregateRoots.Flight.Create(fn, "XKJ", new DateTime(2024, 11, 04, 17, 20, 0)));

            dbContext.SaveChanges();

            return app;
        }
    }
}