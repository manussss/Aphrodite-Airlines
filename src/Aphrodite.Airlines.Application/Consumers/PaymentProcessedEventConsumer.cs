namespace Aphrodite.Airlines.Application.Consumers;

public class PaymentProcessedEventConsumer(IMediator mediator) : IConsumer<PaymentProcessedEvent>
{
    public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
    {
        var paymentProcessedEvent = context.Message;
        var message = $"Payment of ${paymentProcessedEvent.Amount} for bookingId: {paymentProcessedEvent.BookingId} was processed successfully";
        var command = new SendNotificationCommand("test@mail.com", message, "Email");

        await mediator.Send(command);
    }
}