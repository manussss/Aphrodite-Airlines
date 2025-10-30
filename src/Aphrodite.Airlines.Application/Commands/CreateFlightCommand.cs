namespace Aphrodite.Airlines.Application.Commands;

public record CreateFlightCommand(
    string FlightNumber,
    string Origin,
    string Destination,
    DateTime DepartureDate,
    DateTime ArrivalDate) : IRequest<Guid>;