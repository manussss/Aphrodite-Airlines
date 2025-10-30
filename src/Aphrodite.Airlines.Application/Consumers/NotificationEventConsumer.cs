namespace Aphrodite.Airlines.Application.Consumers;

public class NotificationEventConsumer(ILogger<NotificationEventConsumer> logger) : IConsumer<NotificationEvent>
{
    public async Task Consume(ConsumeContext<NotificationEvent> context)
    {
        var notificationEvent = context.Message;

        logger.LogInformation("Notification received | Message: {Message}", notificationEvent.Message);

        await Task.CompletedTask;
    }
}