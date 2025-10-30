namespace Aphrodite.Airlines.Domain.Interfaces;

public interface IPaymentRepository
{
    Task ProcessPaymentAsync(Payment payment);
    Task RefundPaymentAsync(Guid id);
}