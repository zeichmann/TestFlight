namespace Neuca.TestFlight.Domain.DomainExceptions;

public class DomainException : Exception
{
    public string Code { get; set; }
    
    public string Message { get; set; }
}