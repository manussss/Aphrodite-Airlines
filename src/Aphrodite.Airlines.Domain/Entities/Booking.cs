namespace Aphrodite.Airlines.Domain.Entities;

public class Booking
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public string PassengerName { get; set; }
    public string SeatNumber { get; set; }
    public DateTime BookingDate { get; set; }
}