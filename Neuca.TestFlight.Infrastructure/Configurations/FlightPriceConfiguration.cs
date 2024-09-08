using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;

namespace Neuca.TestFlight.Infrastructure.Configurations
{
    public class FlightPriceConfiguration : IEntityTypeConfiguration<FlightPrice>
    {
        public void Configure(EntityTypeBuilder<FlightPrice> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.FlightNumber).WithMany(x=>x.Prices).HasForeignKey(x=>x.FlightNumberId);
        }
    
    }
}

