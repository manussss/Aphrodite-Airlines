namespace Aphrodite.Airlines.Application.Handlers;

public class CreateFlightHandler(
    IFlightRepository repository) : IRequestHandler<CreateFlightCommand, Guid>
{
    public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var flight = new Flight
        {
            Id = Guid.NewGuid(),
            FlightNumber = request.FlightNumber,
            Origin = request.Origin,
            Destination = request.Destination,
            DepartureDate = request.DepartureDate,
            ArrivalDate = request.ArrivalDate
        };

        await repository.AddAsync(flight);

        return flight.Id;
    }
}