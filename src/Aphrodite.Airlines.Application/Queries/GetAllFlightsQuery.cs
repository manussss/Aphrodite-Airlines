namespace Aphrodite.Airlines.Application.Queries;

public record GetAllFlightsQuery() : IRequest<IEnumerable<Flight>>;