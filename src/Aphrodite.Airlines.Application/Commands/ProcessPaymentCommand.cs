namespace Aphrodite.Airlines.Application.Commands;

public record ProcessPaymentCommand(Guid BookingId, decimal Amount) : IRequest<Guid>;