namespace Aphrodite.Airlines.Application.Consumers;

public class FlightBookedEventConsumer(IMediator mediator) : IConsumer<FlightBookedEvent>
{
    public async Task Consume(ConsumeContext<FlightBookedEvent> context)
    {
        var flightBookedEvent = context.Message;
        var command = new ProcessPaymentCommand(flightBookedEvent.BookingId, 200.00m);

        await mediator.Send(command);
    }
}