using MediatR;
using Neuca.TestFlight.Infrastructure.ApiResponses.TenantArea;

namespace Neuca.TestFlight.Application.TenantArea.Queries;

public record GetTenantsQuery : IRequest<List<TenantResponse>>;