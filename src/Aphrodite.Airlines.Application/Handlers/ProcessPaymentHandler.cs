namespace Aphrodite.Airlines.Application.Handlers;

public class ProcessPaymentHandler(
    IPaymentRepository repository,
    IPublishEndpoint publishEndpoint) : IRequestHandler<ProcessPaymentCommand, Guid>
{
    public async Task<Guid> Handle(ProcessPaymentCommand request, CancellationToken cancellationToken)
    {
        var payment = new Payment
        {
            Id = Guid.NewGuid(),
            BookingId = request.BookingId,
            Amount = request.Amount,
            PaymentDate = DateTime.UtcNow
        };

        await repository.ProcessPaymentAsync(payment);

        await publishEndpoint.Publish(new PaymentProcessedEvent(
            payment.Id,
            payment.BookingId,
            payment.Amount,
            payment.PaymentDate), cancellationToken);

        return payment.Id;
    }
}