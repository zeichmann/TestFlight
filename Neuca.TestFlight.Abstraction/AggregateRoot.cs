namespace NeucaTestFlight.Abstraction;

public abstract class AggregateRoot
{
    public Guid Id { get; set; }

    public AggregateRoot()
    {
        Id = Guid.NewGuid();
    }
};