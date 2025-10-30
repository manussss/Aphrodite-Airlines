namespace Aphrodite.Airlines.Application.Commands;

public record SendNotificationCommand(
    string Recipient,
    string Message,
    string Type) : IRequest;