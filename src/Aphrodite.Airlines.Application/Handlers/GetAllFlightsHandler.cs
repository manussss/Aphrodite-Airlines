namespace Aphrodite.Airlines.Application.Handlers;

public class GetAllFlightsHandler(
    IFlightRepository repository) : IRequestHandler<GetAllFlightsQuery, IEnumerable<Flight>>
{
    public async Task<IEnumerable<Flight>> Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync();
    }
}