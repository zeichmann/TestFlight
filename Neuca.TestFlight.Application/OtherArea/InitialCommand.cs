using MediatR;

namespace Neuca.TestFlight.Application.OtherArea;

public record InitialCommand : IRequest;

public class InitialCommandHandler() :  IRequestHandler<InitialCommand>
{
        public Task Handle(InitialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
}

