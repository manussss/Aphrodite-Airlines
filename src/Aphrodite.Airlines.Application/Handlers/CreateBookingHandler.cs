namespace Aphrodite.Airlines.Application.Handlers;

public class CreateBookingHandler(
    IBookingRepository repository,
    IPublishEndpoint publishEndpoint) : IRequestHandler<CreateBookingCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = new Booking
        {
            Id = Guid.NewGuid(),
            FlightId = request.FlightId,
            PassengerName = request.PassengerName,
            SeatNumber = request.SeatNumber,
            BookingDate = DateTime.UtcNow
        };

        await repository.AddAsync(booking);

        await publishEndpoint.Publish(new FlightBookedEvent(
            booking.Id,
            booking.FlightId,
            booking.PassengerName,
            booking.SeatNumber,
            booking.BookingDate), cancellationToken);

        return booking.Id;
    }
}