namespace Aphrodite.Airlines.Infra.Repositories;

public class FlightRepository(IAphroditeContext context) : IFlightRepository
{
    public async Task AddAsync(Flight flight)
    {
        await context.Flights.InsertOneAsync(flight);   
    }

    public async Task DeleteAsync(Guid id)
    {
        await context.Flights.DeleteOneAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        return await context.Flights.Find(flight => true).ToListAsync();
    }
}