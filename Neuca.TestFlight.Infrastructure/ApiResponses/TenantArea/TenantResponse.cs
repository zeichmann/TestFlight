using System.Text.Json.Serialization;
using Neuca.TestFlight.Domain.AggregateRoots;
using Neuca.TestFlight.Infrastructure.ApiResponses.CriteriaArea;
using Neuca.TestFlight.Infrastructure.ApiResponses.NeucaUserArea;

namespace Neuca.TestFlight.Infrastructure.ApiResponses.TenantArea;

public class TenantResponse
{
    public string Code { get; set; }

    public string DllReference { get; set;  }

    public string FullServiceClassName { get; set; }
}