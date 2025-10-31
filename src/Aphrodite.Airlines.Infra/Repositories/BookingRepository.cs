namespace Aphrodite.Airlines.Infra.Repositories;

public class BookingRepository(
    IDbConnection connection,
    IDatabase redisDatabase,
    IConnectionMultiplexer connectionMultiplexer) : IBookingRepository
{
    private const string RedisKeyPrefix = "booking_";
    private IDatabase redisDatabase { get; } = connectionMultiplexer.GetDatabase();

    public async Task AddAsync(Booking booking)
    {
        var sql = @"
            INSERT INTO Bookings (Id, FlightId, PassengerName, SeatNumber, BookingDate)
            VALUES (@Id, @FlightId, @PassengerName, @SeatNumber, @BookingDate)
        ";

        await connection.ExecuteAsync(sql, booking);

        var data = JsonSerializer.Serialize(booking);
        await redisDatabase.StringSetAsync($"{RedisKeyPrefix}{booking.Id}", data);
    }

    public async Task<Booking?> GetByIdAsync(Guid id)
    {
        var sql = @"
            SELECT * FROM Bookings WHERE Id = @Id
        ";

        var booking = await redisDatabase.StringGetAsync($"{RedisKeyPrefix}{id}");

        if (string.IsNullOrEmpty(booking))
            return await connection.QuerySingleOrDefaultAsync(sql, new { Id = id });

        return JsonSerializer.Deserialize<Booking>(booking!);
    }
}