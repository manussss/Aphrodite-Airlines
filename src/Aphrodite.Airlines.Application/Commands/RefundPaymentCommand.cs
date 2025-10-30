namespace Aphrodite.Airlines.Application.Commands;

public record RefundPaymentCommand(Guid PaymentId) : IRequest;