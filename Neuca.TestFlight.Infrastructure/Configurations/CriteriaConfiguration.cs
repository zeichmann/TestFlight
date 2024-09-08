using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;

namespace Neuca.TestFlight.Infrastructure.Configurations;

public class CriteriaConfiguration : IEntityTypeConfiguration<Criteria>
{
    public void Configure(EntityTypeBuilder<Criteria> builder)
    {
        builder.HasKey(type => type.Id);
        builder.HasOne(x => x.Tenant).WithMany(x=>x.Criteria).HasForeignKey(x=>x.TenantId);
        builder.HasOne(x => x.User).WithMany(x=>x.Criteria).HasForeignKey(x=>x.UserId);;
        
        
    }
}

