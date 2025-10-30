namespace Aphrodite.Airlines.Infra.Repositories;

public class NotificationRepository(IDbConnection connection) : INotificationRepository
{
    public async Task LogNotificationAsync(Notification notification)
    {
        var sql = @"
            INSERT INTO Notification (Id, Recipient, Message, Type, SentAt)
            VALUES (@Id, @Recipient, @Message, @Type, @SentAt)
        ";

        await connection.ExecuteAsync(sql, notification);
    }
}