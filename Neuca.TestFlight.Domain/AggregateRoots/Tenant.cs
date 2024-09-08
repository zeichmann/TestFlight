using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using NeucaTestFlight.Abstraction;

namespace Neuca.TestFlight.Domain.AggregateRoots;

public class Tenant : AggregateRoot
{
    private Tenant()
    {
    }
    
    public string Code { get; set; }
    
    public string DllReference { get; set; }
    
    //namespace + class number
    public string FullServiceClassName   { get; set; }
    
    [JsonIgnore]
    public List<NeucaUser> NeucaUsers { get; set; }

    [JsonIgnore]
    public List<Criteria> Criteria { get; set; }
    
    public static Tenant Create(string code, string dllReference, string fullServiceClassName)
    {
        return new Tenant()
        {
            Code = code,
            DllReference = dllReference,
            FullServiceClassName = fullServiceClassName
        };
    }
}

