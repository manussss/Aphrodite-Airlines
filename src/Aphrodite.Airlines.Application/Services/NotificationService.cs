namespace Aphrodite.Airlines.Application.Services;

public class NotificationService(
    ILogger<NotificationService> logger) : INotificationService
{
    public async Task SendNotificationAsync(Notification notification)
    {
        //Simulate sending a notification
        logger.LogInformation("Sending notification message: {Message}", notification.Message);
    }
}