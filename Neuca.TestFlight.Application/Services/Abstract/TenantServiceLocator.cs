using System.Reflection;
using Neuca.TestFlight.Domain.Abstractions;
using Neuca.TestFlight.Domain.DomainExceptions;
using Neuca.TestFlight.Infrastructure.IdentityEmulator;

namespace Neuca.TestFlight.Application.Services.Abstract;

public abstract class TenantServiceLocator
{
    protected IdentityService identityService;

    protected ITenantService tenantService;
    
    public TenantServiceLocator(IdentityService identityService)
    {
        this.identityService = identityService;
        var assembly = Assembly.LoadFrom(identityService.LoggedUser().Tenant.DllReference);
        var type = assembly.GetType(identityService.LoggedUser().Tenant.FullServiceClassName);

        if (type != null && typeof(ITenantService).IsAssignableFrom(type))
        {
            tenantService = (ITenantService)Activator.CreateInstance(type);
        }
        else
        {
            Console.WriteLine("This type do not implement ITenantService");
        }
    }
}