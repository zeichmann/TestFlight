using AutoMapper;
using MediatR;
using Neuca.TestFlight.Application.CriteriaArea.Queries;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.ApiResponses.CriteriaArea;

namespace Neuca.TestFlight.Application.CriteriaArea.QueryHandlers;

public class GetCriteriaQueryHandler(IMapper mapper, InMemoryDbContext dbContext)
    : IRequestHandler<GetCriteriaQuery, List<CriteriaResponse>>
{
    public Task<List<CriteriaResponse>> Handle(GetCriteriaQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(mapper.Map<List<CriteriaResponse>>(dbContext.Criteria.ToList()));
    }
}