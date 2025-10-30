namespace Aphrodite.Airlines.Application.Handlers;

public class ProcessPaymentHandler(
    IPaymentRepository repository) : IRequestHandler<ProcessPaymentCommand, Guid>
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

        return payment.Id;
    }
}