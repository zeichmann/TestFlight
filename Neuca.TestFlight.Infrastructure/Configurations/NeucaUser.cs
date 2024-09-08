using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;

namespace Neuca.TestFlight.Infrastructure.Configurations;

public class NeucaUserConfiguration : IEntityTypeConfiguration<NeucaUser>
{
    public void Configure(EntityTypeBuilder<NeucaUser> builder)
    {
        builder.HasKey(type => type.Id);
        builder.HasOne(x => x.Tenant)
            .WithMany(x => x.NeucaUsers)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}

