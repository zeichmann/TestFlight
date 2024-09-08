using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;

namespace Neuca.TestFlight.Infrastructure.Configurations;

public class FlightNumbereConfiguration : IEntityTypeConfiguration<FlightNumber>
{
    public void Configure(EntityTypeBuilder<FlightNumber> builder)
    {
        builder.HasKey(type => type.Id);
        builder.HasMany(x=>x.Prices).WithOne(x=>x.FlightNumber).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(x=>x.Flights).WithOne(x=>x.FlightNumber).OnDelete(DeleteBehavior.Cascade);
    }
    
}

