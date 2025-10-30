namespace Aphrodite.Airlines.Infra.Repositories;

public class BookingRepository(IDbConnection connection) : IBookingRepository
{
    public async Task AddAsync(Booking booking)
    {
        var sql = @"
            INSERT INTO Bookings (Id, FlightId, PassengerName, SeatNumber, BookingDate)
            VALUES (@Id, @FlightId, @PassengerName, @SeatNumber, @BookingDate)
        ";

        await connection.ExecuteAsync(sql, booking);
    }

    public async Task<Booking?> GetByIdAsync(Guid id)
    {
        var sql = @"
            SELECT * FROM Bookings WHERE Id = @Id
        ";

        return await connection.QuerySingleOrDefaultAsync(sql, new { Id = id });
    }
}