namespace Aphrodite.Airlines.Application.Queries;

public record GetBookingQuery(Guid Id) : IRequest<Booking>;