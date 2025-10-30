namespace Aphrodite.Airlines.Shared.Events;

public record PaymentProcessedEvent(
    Guid PaymentId,
    Guid BookingId,
    decimal Amount,
    DateTime PaymentDate);