using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Domain.ValueObjects;

namespace Neuca.TestFlight.Infrastructure;
//using Microsoft.EntityFrameworkCore;

public class InMemoryDbContext : DbContext
{
    public DbSet<Domain.AggregateRoots.Flight> Flights { get; set; }
    
    public DbSet<FlightNumber> FlightNumbers { get; set; }
    
    public DbSet<FlightPrice> FlightPrices { get; set; }
    
    public DbSet<Tenant> Tenants { get; set; }
    
    public DbSet<NeucaUser> NeucaUsers { get; set; }
    
    public DbSet<Criteria> Criteria { get; set; }

    public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(InMemoryDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    
    public string ExportDbContextToJson()
    {
        var model = this.Model.GetEntityTypes(); // Pobieranie typów encji
        var entities = model.Select(e => new
        {
            Name = e.ShortName(), // Nazwa encji (np. tabela)
            Properties = e.GetProperties().Select(p => new
            {
                PropertyName = p.Name, // Nazwa właściwości
                PropertyType = p.ClrType.Name, // Typ właściwości (np. int, string)
                IsPrimaryKey = p.IsPrimaryKey(), // Czy to klucz główny
                IsNullable = p.IsNullable // Czy kolumna jest nullowalna
            }),
            Keys = e.GetKeys().Select(k => new
            {
                KeyName = k.Properties.Select(p => p.Name).ToList()
            }),
            ForeignKeys = e.GetForeignKeys().Select(fk => new
            {
                PrincipalTable = fk.PrincipalEntityType.ShortName(),
                PrincipalColumns = fk.PrincipalKey.Properties.Select(p => p.Name).ToList(),
                DependentColumns = fk.Properties.Select(p => p.Name).ToList()
            })
        });

        return JsonSerializer.Serialize(entities, new JsonSerializerOptions { WriteIndented = true });
    }

    public class Property
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsNullable { get; set; }
    }

    public class Key
    {
        public List<string> KeyName { get; set; }
    }

    public class ForeignKey
    {
        public string PrincipalTable { get; set; }
        public List<string> PrincipalColumns { get; set; }
        public List<string> DependentColumns { get; set; }
    }

    public class Node
    {
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
        public List<Key> Keys { get; set; }
        public List<ForeignKey> ForeignKeys { get; set; }
    }

}