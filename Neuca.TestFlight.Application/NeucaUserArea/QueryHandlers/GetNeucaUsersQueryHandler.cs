using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Neuca.TestFlight.Application.NeucaUserArea.Queries;
using Neuca.TestFlight.Application.OtherArea;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.ApiResponses.NeucaUserArea;

namespace Neuca.TestFlight.Application.NeucaUserArea.QueryHandlers;

public class GetNeucaUsersQueryHandler(IMapper mapper, InMemoryDbContext dbContext) :  IRequestHandler<GetNeucaUsersQuery, List<NeucaUserResponse>>
{
        public async Task<List<NeucaUserResponse>> Handle(GetNeucaUsersQuery request, CancellationToken cancellationToken)
        {
             return mapper.Map<List<NeucaUserResponse>>(dbContext.NeucaUsers.Include(x=>x.Tenant).Include(x=>x.Criteria).ToList());
        }
}

