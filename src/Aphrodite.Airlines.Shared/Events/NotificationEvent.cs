namespace Aphrodite.Airlines.Shared.Events;

public record NotificationEvent(
    string Recipient,
    string Message,
    string Type);