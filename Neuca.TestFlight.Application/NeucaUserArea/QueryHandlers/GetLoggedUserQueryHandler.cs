using AutoMapper;
using MediatR;
using Neuca.TestFlight.Application.NeucaUserArea.Queries;
using Neuca.TestFlight.Application.OtherArea;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.ApiResponses.NeucaUserArea;
using Neuca.TestFlight.Infrastructure.IdentityEmulator;

namespace Neuca.TestFlight.Application.NeucaUserArea.QueryHandlers;

public class GetLoggedUserQueryHandler(IMapper mapper, IdentityService identityService) :  IRequestHandler<GetLoggedUserQuery, NeucaUserResponse>
{
        public async Task<NeucaUserResponse> Handle(GetLoggedUserQuery request, CancellationToken cancellationToken)
        {
             return mapper.Map<NeucaUserResponse>(identityService.LoggedUser());
        }
}

