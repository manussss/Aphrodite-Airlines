namespace Aphrodite.Airlines.Domain.Interfaces;

public interface INotificationRepository
{
    Task LogNotificationAsync(Notification notification);
}