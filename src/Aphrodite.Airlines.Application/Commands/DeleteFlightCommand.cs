namespace Aphrodite.Airlines.Application.Commands;

public record DeleteFlightCommand(Guid Id) : IRequest;