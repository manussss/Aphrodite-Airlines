namespace Aphrodite.Airlines.Infra.Data;

public interface IAphroditeContext
{
    IMongoCollection<Flight> Flights { get; }
}