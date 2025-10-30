namespace Aphrodite.Airlines.Domain.Interfaces;

public interface IFlightRepository
{
    Task<IEnumerable<Flight>> GetAllAsync();
    Task AddAsync(Flight flight);
    Task DeleteAsync(Guid id);
}