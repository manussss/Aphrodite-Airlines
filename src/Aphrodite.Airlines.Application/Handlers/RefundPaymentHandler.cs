namespace Aphrodite.Airlines.Application.Handlers;

public class RefundPaymentHandler(
    IPaymentRepository repository) : IRequestHandler<RefundPaymentCommand>
{
    public async Task Handle(RefundPaymentCommand request, CancellationToken cancellationToken)
    {
        await repository.RefundPaymentAsync(request.PaymentId);
    }
}