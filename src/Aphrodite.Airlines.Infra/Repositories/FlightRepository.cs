namespace Aphrodite.Airlines.Infra.Repositories;

public class FlightRepository(IDbConnection connection) : IFlightRepository
{
    public async Task AddAsync(Flight flight)
    {
        var sql = @"
            INSERT INTO Flights (Id, FlightNumber, Origin, Destination, DepartureDate, ArrivalDate)
            VALUES (@Id, @FlightNumber, @Origin, @Destination, @DepartureDate, @ArrivalDate)
        ";

        await connection.ExecuteAsync(sql, flight);
    }

    public async Task DeleteAsync(Guid id)
    {
        var sql = @"
            DELETE FROM Flights WHERE Id = @Id;
        ";

        await connection.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        var sql = @"
            SELECT * FROM Flights;
        ";

        return await connection.QueryAsync<Flight>(sql);
    }
}