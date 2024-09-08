using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neuca.TestFlight.Domain.ValueObjects;

namespace Neuca.TestFlight.Infrastructure.Configurations;

public class FlightConfiguration : IEntityTypeConfiguration<Domain.AggregateRoots.Flight>
{
    public void Configure(EntityTypeBuilder<Domain.AggregateRoots.Flight> builder)
    {
        builder.HasKey(type => type.Id);
        builder.HasOne(x=>x.FlightNumber).WithMany(x=>x.Flights).HasForeignKey(x=>x.FlightNumberId);
    }
    
}

