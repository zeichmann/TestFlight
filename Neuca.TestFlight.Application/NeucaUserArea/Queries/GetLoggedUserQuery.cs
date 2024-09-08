using MediatR;
using Neuca.TestFlight.Infrastructure.ApiResponses.NeucaUserArea;

namespace Neuca.TestFlight.Application.NeucaUserArea.Queries;

public record GetLoggedUserQuery : IRequest<NeucaUserResponse>;