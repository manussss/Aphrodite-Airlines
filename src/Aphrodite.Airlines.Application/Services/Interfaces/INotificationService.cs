namespace Aphrodite.Airlines.Application.Services.Interfaces;

public interface INotificationService
{
    Task SendNotificationAsync(Notification notification);
}