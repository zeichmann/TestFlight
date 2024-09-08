namespace NeucaTestFlight.Abstraction;

public abstract class ValueObject
{
    public Guid Id { get; set; }

    public ValueObject()
    {
        Id = Guid.NewGuid();
    }
}