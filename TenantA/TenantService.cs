using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Neuca.TestFlight.Domain.Abstractions;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.DomainExceptions;
using Neuca.TestFlight.Infrastructure;

namespace TenantA;

public class TenantService() : ITenantService
{
    public decimal CountPrice(NeucaUser user, Flight flight)
    {
        //workaround just to use the same inmemory db to store criteria
        var serviceProvider = ServiceLocator.ServiceProvider;
        
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<InMemoryDbContext>();
            var flyHour = new TimeSpan(flight.FlightTime.Hour, flight.FlightTime.Minute, flight.FlightTime.Second);
            decimal initialPrice = 0;
            var currentPrice = flight.FlightNumber.Prices.FirstOrDefault(x => x.Hour.ToString() == flyHour.ToString());
            
            if (currentPrice == null)
            {
                throw new DomainException()
                {
                    Message = "No flight in this time"
                };
            }
            initialPrice = currentPrice.Price;
            decimal totalDiscount = 0;

            if (user.DateOfBirth.Month == flight.FlightTime.Month && user.DateOfBirth.Day == flight.FlightTime.Day)
            {
                totalDiscount += 5;
                dbContext.Criteria.Add( Criteria.Create(user.Id, user.Tenant.Id, "Birthday", 5, initialPrice, flight.Id));    
            }

            if (flight.FlightNumber.Continent.Equals("Africa"))
            {
                totalDiscount += 5;
                dbContext.Criteria.Add( Criteria.Create(user.Id, user.Tenant.Id, "Africa", 5, initialPrice, flight.Id));
            }

            if (initialPrice - totalDiscount < 20)
            {
                return initialPrice;
            }

            dbContext.SaveChanges();
            return initialPrice - totalDiscount;
        }
    }
}

