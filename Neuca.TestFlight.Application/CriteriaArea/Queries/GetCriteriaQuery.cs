using MediatR;
using Neuca.TestFlight.Infrastructure.ApiResponses.CriteriaArea;

namespace Neuca.TestFlight.Application.CriteriaArea.Queries;

public record GetCriteriaQuery : IRequest<List<CriteriaResponse>>;