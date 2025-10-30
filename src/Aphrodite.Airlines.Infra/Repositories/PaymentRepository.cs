namespace Aphrodite.Airlines.Infra.Repositories;

public class PaymentRepository(IDbConnection connection) : IPaymentRepository
{
    public async Task ProcessPaymentAsync(Payment payment)
    {
        var sql = @"
            INSERT INTO Payments (Id, BookingId, Amount, PaymentDate)
            VALUES (@Id, @BookingId, @Amount, @PaymentDate)
        ";

        await connection.ExecuteAsync(sql, payment);
    }

    public async Task RefundPaymentAsync(Guid id)
    {
        var sql = @"
            DELETE FROM Payments WHERE Id = @Id
        ";

        await connection.ExecuteAsync(sql, new { Id = id });
    }
}