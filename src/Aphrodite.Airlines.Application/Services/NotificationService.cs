namespace Aphrodite.Airlines.Application.Services;

public class NotificationService(
    ILogger<NotificationService> logger,
    IPublishEndpoint publishEndpoint) : INotificationService
{
    public async Task SendNotificationAsync(Notification notification)
    {
        //Simulate sending a notification
        logger.LogInformation("Sending notification message: {Message}", notification.Message);

        var notificationEvent = new NotificationEvent(notification.Recipient, notification.Message, notification.Type);

        await publishEndpoint.Publish(notificationEvent);
    }
}