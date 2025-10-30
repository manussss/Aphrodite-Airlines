namespace Aphrodite.Airlines.Application.Handlers;

public class SendNotificationHandler(
    INotificationService notificationService) : IRequestHandler<SendNotificationCommand>
{
    public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
    {
        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            Recipient = request.Recipient,
            Message = request.Message,
            Type = request.Type
        };

        await notificationService.SendNotificationAsync(notification);
    }
}