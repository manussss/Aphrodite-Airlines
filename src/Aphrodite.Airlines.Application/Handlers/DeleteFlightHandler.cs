namespace Aphrodite.Airlines.Application.Handlers;

public class DeleteFlightHandler(
    IFlightRepository repository) : IRequestHandler<DeleteFlightCommand>
{
    public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
    }
}